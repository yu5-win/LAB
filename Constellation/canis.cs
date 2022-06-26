using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class canis : MonoBehaviour
{
    public SteamVR_Input_Sources handType; //모두 사용, 왼손, 오른손
    public SteamVR_Behaviour_Pose controllerPose; //컨트롤러 정보
    public SteamVR_Action_Boolean grabAction; //그랩 액션

    public GameObject laserPointerPrefab; // 레이저 포인터 프리팹
    private GameObject laserPointer; // 레이저포인터(인스턴스)
    private Transform laserPointerTransform; //레이저 포인터 트랜스폼
    private Vector3 laserPointerhitPoint; // 레이저 포인터 부딪힌부분
    public LayerMask laserPointerMask; // 레이저 포인터가 나오는 레이어 마스크

    public GameObject player;
    public GameObject line;

    GameObject[] star = new GameObject[2];

    [Header("Canis Major")]
    public bool[] starChoose = new bool[19]; // 선이 그어졌는지 확인
    public GameObject[] canis_star = new GameObject[17]; // 별
    public GameObject[] canis_par = new GameObject[17];  // 파티클
    [Header("Virgo")]
    public bool[] virgoChoose = new bool[14];
    public GameObject[] virgo_star = new GameObject[15];
    public GameObject[] virgo_par = new GameObject[15];
    [Header("Gemini")]
    public bool[] geminiChoose = new bool[15];
    public GameObject[] gemini_star = new GameObject[17];
    public GameObject[] gemini_par = new GameObject[17];
    [Header("Leo")]
    public bool[] leoChoose = new bool[11];
    public GameObject[] leo_star = new GameObject[10];
    public GameObject[] leo_par = new GameObject[10];
    [Header("Clear")]
    public bool leoAll;
    public bool canisAll;
    public bool virgoAll;
    public bool geminiAll;
    public GameObject clear;

    private bool is_created = false;
    float dist;
    GameObject obj;

    void Start()
    {
        //레이저 포인터 프리팹 생성
        laserPointer = Instantiate(laserPointerPrefab);
        laserPointerTransform = laserPointer.transform;
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 10000, laserPointerMask))
        {
            //별 두개 선택
            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.tag == "star" && star[0] == null)
            {
                star[0] = hit.transform.gameObject;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.tag == "star" && star[0] != null)
            {
                star[1] = hit.transform.gameObject;
            }
            laserPointerhitPoint = hit.point;
            ShowLaser(hit);
        }
        else
        {
            laserPointer.SetActive(false);
        }
        //선택한 별자리로 이동
        if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "back")
        {
            player.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 10.0f);
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "Zero")
        {
            player.transform.position = new Vector3(8.76f, -1.51f, -24.65f);
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "spring")
        {
            SceneManager.LoadScene("01. Spring");
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "summer")
        {
            SceneManager.LoadScene("02. Summer");
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "autumn")
        {
            SceneManager.LoadScene("03. Autumn");
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "winter")
        {
            SceneManager.LoadScene("04. Winter");
        }

        if (star[0] && star[1] != null)
        {
            Answer(0, 1, 0);
            Answer(0, 2, 1);
            Answer(1, 2, 2);
            Answer(1, 3, 3);
            Answer(3, 4, 4);
            Answer(3, 7, 5);
            Answer(4, 5, 6);
            Answer(4, 6, 7);
            Answer(4, 8, 8);
            Answer(7, 8, 9);
            Answer(7, 9, 10);
            Answer(8, 10, 11);
            Answer(9, 10, 12);
            Answer(9, 16, 13);
            Answer(10, 11, 14);
            Answer(11, 12, 15);
            Answer(11, 13, 16);
            Answer(12, 14, 17);
            Answer(15, 16, 18);

            leoAnswer(0, 1, 0);
            leoAnswer(1, 2, 1);
            leoAnswer(2, 3, 2);
            leoAnswer(3, 4, 3);
            leoAnswer(3, 8, 4);
            leoAnswer(4, 5, 5);
            leoAnswer(5, 6, 6);
            leoAnswer(5, 7, 7);
            leoAnswer(7, 8, 8);
            leoAnswer(7, 9, 9);
            leoAnswer(8, 9, 10);

            virgoAnswer(0, 1, 0);
            virgoAnswer(1, 2, 1);
            virgoAnswer(2, 3, 2);
            virgoAnswer(3, 4, 3);
            virgoAnswer(3, 7, 4);
            virgoAnswer(3, 9, 5);
            virgoAnswer(4, 5, 6);
            virgoAnswer(4, 10, 7);
            virgoAnswer(5, 6, 8);
            virgoAnswer(7, 8, 9);
            virgoAnswer(10, 11, 10);
            virgoAnswer(10, 13, 11);
            virgoAnswer(10, 14, 12);
            virgoAnswer(11, 12, 13);

            geminiAnswer(0, 1, 0);
            geminiAnswer(1, 2, 1);
            geminiAnswer(1, 3, 2);
            geminiAnswer(3, 9, 3);
            geminiAnswer(4, 5, 4);
            geminiAnswer(4, 6, 5);
            geminiAnswer(5, 7, 6);
            geminiAnswer(6, 8, 7);
            geminiAnswer(9, 10, 8);
            geminiAnswer(9, 11, 9);
            geminiAnswer(9, 12, 10);
            geminiAnswer(12, 13, 11);
            geminiAnswer(12, 14, 12);
            geminiAnswer(14, 15, 13);
            geminiAnswer(15, 16, 14);
            geminiAnswer(1, 4, 15);

            star[0] = null;
            star[1] = null;
        }
        if(starChoose[0]==true && starChoose[1] == true && starChoose[2] == true && starChoose[3] == true && starChoose[4] == true && starChoose[5] == true && starChoose[6] == true && starChoose[7] == true && starChoose[8] == true && starChoose[9] == true && starChoose[10] == true && starChoose[11] == true && starChoose[12] == true && starChoose[13] == true && starChoose[14] == true && starChoose[15] == true && starChoose[16] == true && starChoose[17] == true && starChoose[18] == true)
        {
            canisAll = true;
        }
        else if (leoChoose[0] == true && leoChoose[1] == true && leoChoose[2] == true && leoChoose[3] == true && leoChoose[4] == true && leoChoose[5] == true && leoChoose[6] == true && leoChoose[7] == true && leoChoose[8] == true && leoChoose[9] == true && leoChoose[10] == true)
        {
            leoAll = true;
        }
        else if (virgoChoose[0] == true && virgoChoose[1] == true && virgoChoose[2] == true && virgoChoose[3] == true && virgoChoose[4] == true && virgoChoose[5] == true && virgoChoose[6] == true && virgoChoose[7] == true && virgoChoose[8] == true && virgoChoose[9] == true && virgoChoose[10] == true && virgoChoose[11] == true && virgoChoose[12] == true && virgoChoose[13] == true)
        {
            virgoAll = true;
        }
        else if (geminiChoose[0] == true && geminiChoose[1] == true && geminiChoose[2] == true && geminiChoose[3] == true && geminiChoose[4] == true && geminiChoose[5] == true && geminiChoose[6] == true && geminiChoose[7] == true && geminiChoose[8] == true && geminiChoose[9] == true && geminiChoose[10] == true && geminiChoose[11] == true && geminiChoose[12] == true && geminiChoose[13] == true && geminiChoose[14] == true && geminiChoose[15] == true)
        {
            geminiAll = true;
        }

        if (canisAll == true && leoAll == true && geminiAll == true && virgoAll == true)
        {
            clear.SetActive(true);
        }

        if (is_created)
        {
            Vector3 lineLen = line.transform.localScale;
            if (obj.transform.localScale.y < dist)
            {
                lineLen.y = 0.1f;
                obj.transform.localScale += new Vector3(0.0f, lineLen.y, 0.0f); // 길이 결정
            }
            else if(obj.transform.localScale.y >= dist)
            {
                //초기화
                star[0] = null;
                star[1] = null;
                is_created = false;
                lineLen.y = 0.0f;
            }
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laserPointer.SetActive(true);
        laserPointer.transform.position = Vector3.Lerp(controllerPose.transform.position, laserPointerhitPoint, 0.5f);
        laserPointerTransform.LookAt(laserPointerhitPoint);
        laserPointerTransform.localScale = new Vector3(laserPointerTransform.localScale.x, laserPointerTransform.localScale.y, hit.distance);
    }
    //선 그리기
    private void DrawLine()
    {
        //크기
        dist = Vector3.Distance(star[0].transform.position, star[1].transform.position);
        //각도
        Vector3 v = star[1].transform.position - star[0].transform.position;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        //생성
        obj = Instantiate(line, new Vector3((star[0].transform.position.x + star[1].transform.position.x) / 2, (star[0].transform.position.y + star[1].transform.position.y) / 2, (star[0].transform.position.z + star[1].transform.position.z) / 2), Quaternion.Euler(0, 0, angle - 90));
        //obj.transform.localScale = new Vector3(0.1f, dist, 0.1f); // 길이 결정
        is_created = true;
    }
    // canis 답
    private void Answer(int a, int b, int c)
    {
        if ((star[0] == canis_star[a] && star[1] == canis_star[b]) || (star[1] == canis_star[a] && star[0] == canis_star[b]))
        {
            canis_par[a].SetActive(true);
            canis_par[b].SetActive(true);
            starChoose[c] = true;
            DrawLine();
        }
    }
    // leo 답
    private void leoAnswer(int a, int b, int c)
    {
        if ((star[0] == leo_star[a] && star[1] == leo_star[b]) || (star[1] == leo_star[a] && star[0] == leo_star[b]))
        {
            leo_par[a].SetActive(true);
            leo_par[b].SetActive(true);
            leoChoose[c] = true;
            DrawLine();
        }
    }
    // virgo 답
    private void virgoAnswer(int a, int b, int c)
    {
        if ((star[0] == virgo_star[a] && star[1] == virgo_star[b]) || (star[1] == virgo_star[a] && star[0] == virgo_star[b]))
        {
            virgo_par[a].SetActive(true);
            virgo_par[b].SetActive(true);
            virgoChoose[c] = true;
            DrawLine();
        }
    }
    // gemini 답
    private void geminiAnswer(int a, int b, int c)
    {
        if ((star[0] == gemini_star[a] && star[1] == gemini_star[b]) || (star[1] == gemini_star[a] && star[0] == gemini_star[b]))
        {
            gemini_par[a].SetActive(true);
            gemini_par[b].SetActive(true);
            geminiChoose[c] = true;
            DrawLine();
        }
    }
}