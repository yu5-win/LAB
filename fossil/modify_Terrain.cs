using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;



public class modify_Terrain : MonoBehaviour
{
    public Description Des;

    public Terrain terrain;
    private TerrainData terrainData;

    public SteamVR_Input_Sources handType; //모두 사용, 왼손, 오른손
    public SteamVR_Behaviour_Pose controllerPose; //컨트롤러 정보
    public SteamVR_Action_Boolean grabAction; //그랩 액션

    private int heightmapWidth;
    private int heightmapHeight;
    private float[,] heights;
    public float amount = 0.03f;

    public int DiggingRange = 5;
    private float grab_elapsed = 0.0f;
    private bool canDig = false;
    public bool is_grab1= false;
    private bool is_tool = false;
    public bool anim_act = false;
    private bool is_dust = false;

    public GameObject shovel_line;
    public GameObject shovel_table;
    public GameObject shovel_img;
    private Vector3 shovel_table_Pos;
    public GameObject brush_line;
    public GameObject brush_table;
    public GameObject brush_img;
    private Vector3 brush_table_Pos;
    private GameObject current_tool = null;

    public GameObject brush_dust;
    public GameObject shovel_dust;

    void Start()
    {
        terrainData = terrain.terrainData;
        heightmapWidth = terrainData.heightmapResolution;
        heightmapHeight = terrainData.heightmapResolution;
        heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
        shovel_table_Pos = new Vector3(shovel_table.transform.position.x, shovel_table.transform.position.y, shovel_table.transform.position.z);
        brush_table_Pos = new Vector3(brush_table.transform.position.x, brush_table.transform.position.y, brush_table.transform.position.z);
    }
    void Update()
    {
        RaycastHit hit;

        if (!is_grab1 && is_tool && grabAction.GetLastState(handType))
        {
            grab_elapsed += Time.deltaTime;

            if (grab_elapsed >= 2.0f)
            {
                is_grab1 = true;
                if(current_tool.gameObject.name == "shovel_table")
                {
                    shovel_table.gameObject.SetActive(false);
                    shovel_img.gameObject.SetActive(true);
                }
                if(current_tool.gameObject.name == "brushes_table")
                {
                    brush_table.gameObject.SetActive(false);
                    brush_img.gameObject.SetActive(true);
                }
                grab_elapsed = 0.0f;
            }
        }
        else if (is_grab1 && grabAction.GetLastState(handType))
        {
            grab_elapsed += 1.0f * Time.deltaTime;

            if (grab_elapsed >= 2.0f)
            {
                is_grab1 = false;
                if (current_tool.gameObject.name == "shovel_table")
                {
                    shovel_table.transform.position = shovel_table_Pos;
                    shovel_table.transform.rotation = Quaternion.Euler(-90, 90, 0);
                    shovel_table.gameObject.SetActive(true);
                    shovel_img.gameObject.SetActive(false);
                    is_tool = false;
                    current_tool = null;
                }
                if(current_tool.gameObject.name == "brushes_table")
                {
                    brush_table.transform.position = brush_table_Pos;
                    brush_table.transform.rotation = Quaternion.Euler(0, -90, 0);
                    brush_table.gameObject.SetActive(true);
                    brush_img.gameObject.SetActive(false);
                    is_tool = false;
                    current_tool = null;
                }
                grab_elapsed = 0.0f;
            }
        }
        else
        {
            grab_elapsed = 0.0f;
        }
        
        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 5))
        {
            if (is_grab1)
            {
                if (hit.transform.gameObject.tag == "Dig" && current_tool.gameObject.name == "shovel_table")
                {
                    canDig = true;
                    shovel_line.SetActive(true);
                    shovel_line.transform.position = new Vector3(hit.point.x, hit.point.y + 1.0f, hit.point.z);
                }
                else if (hit.transform.gameObject.tag == "Dust" && current_tool.gameObject.name == "brushes_table")
                {
                    brush_line.SetActive(true);
                    brush_line.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    is_dust = true;
                }
                else
                {
                    canDig = false;
                    is_dust = false;
                    shovel_line.SetActive(false);
                    brush_line.SetActive(false);
                }

                if (canDig && grabAction.GetLastStateDown(handType))
                {
                    Vector3 point_plus = new Vector3(hit.point.x, hit.point.y + 0.7f, hit.point.z);
                    Instantiate(shovel_dust, point_plus, Quaternion.Euler(0, 0, 0));
                    LowerTerrain(hit.point);
                    //anim_act = true;
                }
                if (is_dust && grabAction.GetLastStateDown(handType))
                {
                    Instantiate(brush_dust, hit.collider.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                    Destroy(hit.collider.gameObject);
                }
                if(hit.collider.gameObject.layer == 8 && grabAction.GetLastStateDown(handType))
                {
                    Des.OnDescription(hit.collider.gameObject);
                }
            }

        }
        else
        {
            shovel_line.SetActive(false);
            brush_line.SetActive(false);
        }
    }
    private void LowerTerrain(Vector3 point)
    {
        int ClickPointX = (int)((point.x / terrainData.size.x) * heightmapWidth);
        int ClickPointZ = (int)((point.z / terrainData.size.z) * heightmapHeight);

        int RectX = ClickPointX - 1;
        int RectZ = ClickPointZ + 1;

        float[,] modifiedHeights = new float[1, 1];
        float ClickPointY = heights[ClickPointX, ClickPointZ];    
        float[,] yValue = new float[DiggingRange, DiggingRange];                        
        //Debug.Log(ClickPointY);
        float New_HeightY = ClickPointY - amount;                  

        for (int i = 0; i < yValue.GetLength(0); i++)              
        {
            for (int j = 0; j < yValue.GetLength(1); j++)
            {
                yValue[i, j] = heights[RectX + j, RectZ - i];
                yValue[i, j] = yValue[i, j] - amount;
                modifiedHeights[0, 0] = yValue[i, j];
                heights[RectX + j, RectZ - i] = yValue[i, j];
                terrainData.SetHeights(RectX + j, RectZ - i, modifiedHeights);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tools")
        {
            if(current_tool == null)
            {
                is_tool = true;
                current_tool = other.gameObject;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Tools")
        {
            if(current_tool == null)
            {
                is_tool = false;
                current_tool = null;
            }
        }
    }
}
