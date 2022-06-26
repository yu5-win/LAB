using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stars
{
    public GameObject[] STAR;
}

public class lineRenderer : MonoBehaviour
{
    public Stars[] starSet;
    public LineRenderer[] lineRender;

    public GameObject[] ClickedStar = new GameObject[2];

    private float counter;
    private float dist;
    private float Inst_Time;
    public float draw_time = 0.0f;
    public float lineDrawSpeed = 6.0f;

    public bool is_checked_0;
    public bool is_checked_1;
    public bool is_init = false;

    private int Star_Index_I = 0;
    private int Star_Index_J = 0;

    private Vector3 pointAlongLine;
    

    void Start()
    {
        Debug.Log(starSet[0].STAR[0]);
    }

    void Update()
    {
        if (ClickedStar[0])
        {
            is_checked_0 = true;
        }
        if (ClickedStar[1])
        {
            is_checked_1 = true;
        }
        if(Input.GetMouseButtonDown(0) && is_checked_0 && is_checked_1)
        {
            if(ClickedStar[0] == ClickedStar[1])
            {
                ClickedStar[0] = null;
                ClickedStar[1] = null;
                is_checked_0 = false;
                is_checked_1 = false;
            }
            FindClickedStar();
        }
        
        if (is_init)
        {
            draw_time += 1.0f * Time.deltaTime;
            DrawStarLine(Star_Index_I);
        }
        else
        {
            draw_time = 0.0f;
        }
    }
    void FindClickedStar()
    {
        for (Star_Index_I = 0; Star_Index_I < starSet.GetLength(0); Star_Index_I++)
        {
            for (Star_Index_J = 0; Star_Index_J < 2; Star_Index_J++)
            {
                if (ClickedStar[0] == starSet[Star_Index_I].STAR[Star_Index_J])
                {
                    CheckOther(Star_Index_I);
                }
            }
            if (is_init)
            {
                break;
            }
        }
        if(Star_Index_I == starSet.GetLength(0) && !is_init)
        {
            is_checked_0 = false;
            is_checked_1 = false;
            ClickedStar[0] = null;
            ClickedStar[1] = null;
        }
    }
    void CheckOther(int Index_I)
    {
        for (int j = 0; j < 2; j++)
        {
            if (ClickedStar[1] == starSet[Index_I].STAR[j])
            {
                is_init = true;
            }
            else if (j == 1 && !is_init)
            {
                return;
            }
        }
    }
    void DrawStarLine(int Index_I)
    {
            lineRender[Index_I].SetPosition(0, ClickedStar[0].transform.position); 
            lineRender[Index_I].SetWidth(.45f, .45f);

            dist = Vector3.Distance(ClickedStar[0].transform.position, ClickedStar[1].transform.position);
            if (pointAlongLine != ClickedStar[1].transform.position)
            {
                counter += 0.1f / lineDrawSpeed * draw_time;

                float x = Mathf.Lerp(0, dist, counter);

                Vector3 pointA = ClickedStar[0].transform.position;
                Vector3 pointB = ClickedStar[1].transform.position;

                pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

                lineRender[Index_I].SetPosition(1, pointAlongLine);
            }
            else if (pointAlongLine == ClickedStar[1].transform.position)
            {
                is_checked_0 = false;
                is_checked_1 = false;
                ClickedStar[0] = null;
                ClickedStar[1] = null;
                pointAlongLine = Vector3.zero;
                counter = 0.0f;
                Star_Index_I = 0;
                Star_Index_J = 0;
                is_init = false;
            }
    }
    
}
