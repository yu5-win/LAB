using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Constellation_ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType; //모두 사용, 왼손, 오른손
    public SteamVR_Behaviour_Pose controllerPose; //컨트롤러 정보
    public SteamVR_Action_Boolean grabAction; //그랩 액션

    private GameObject collidingObject; //현재 충돌중인 객체
    private GameObject objectInHand; //플레이어가 잡은 객체

    public GameObject laserPointerPrefab; // 레이저 포인터 프리팹
    private GameObject laserPointer; // 레이저포인터(인스턴스)
    private Transform laserPointerTransform; //레이저 포인터 트랜스폼
    private Vector3 laserPointerhitPoint; // 레이저 포인터 부딪힌부분
    public LayerMask laserPointerMask; // 레이저 포인터가 나오는 레이어 마스크

    //public bool[] number = new bool[10];
    public GameObject[] line = new GameObject[11];
    public float speed = 10.0f;

    public bool a, b, c, d, e, f, g, h, i, j;

    public bool[] desStar = new bool[11];
    public GameObject[] star = new GameObject[10];
    public GameObject[] parStar = new GameObject[10];

    public GameObject player;

    bool desStar0, desStar1, desStar2, desStar3, desStar4, desStar5, desStar6, desStar7, desStar8, desStar9, desStar10;
    void Start()
    {
        //레이저 포인터 프리팹 생성
        laserPointer = Instantiate(laserPointerPrefab);
        laserPointerTransform = laserPointer.transform;
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 1000, laserPointerMask))
        {
            // 별 선택
            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "one")
            {
                a = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "two")
            {
                b = true; 
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "three")
            {
                c = true; 
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "four")
            {
                d = true; 
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "five")
            {
                e = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "six")
            {
                f = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "seven")
            {
                g = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "eight")
            {
                h = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "nine")
            {
                i = true;
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "ten")
            {
                j = true;
            }
            
            

            if (a == true && b == true)
            {
                drawLine(0);
                desStar[0] = true;
                parStar[0].SetActive(true);
                parStar[1].SetActive(true);
            }
            else if (b == true && c == true)
            {
                drawLine(1);
                desStar[1] = true;
                parStar[1].SetActive(true);
                parStar[2].SetActive(true);
            }
            else if (c == true && d == true)
            {
                drawLine(2);
                desStar[2] = true;
                parStar[2].SetActive(true);
                parStar[3].SetActive(true);
            }
            else if (d == true && e == true)
            {
                drawLine(3);
                desStar[3] = true;
                parStar[3].SetActive(true);
                parStar[4].SetActive(true);
            }
            else if (d == true && i == true)
            {
                drawLine(4);
                desStar[4] = true;
                parStar[3].SetActive(true);
                parStar[8].SetActive(true);
            }
            else if (h == true && i == true)
            {
                drawLine(5);
                desStar[5] = true;
                parStar[7].SetActive(true);
                parStar[8].SetActive(true);
            }
            else if (i == true && j == true)
            {
                drawLine(6);
                desStar[6] = true;
                parStar[8].SetActive(true);
                parStar[9].SetActive(true);
            }
            else if (h == true && j == true)
            {
                drawLine(7);
                desStar[7] = true;
                parStar[7].SetActive(true);
                parStar[9].SetActive(true);
            }
            else if (f == true && h == true)
            {
                drawLine(8);
                desStar[8] = true;
                parStar[5].SetActive(true);
                parStar[7].SetActive(true);
            }
            else if (e == true && f == true)
            {
                drawLine(9);
                desStar[9] = true;
                parStar[4].SetActive(true);
                parStar[5].SetActive(true);
            }
            else if (f == true && g == true)
            {
                drawLine(10);
                desStar[10] = true;
                parStar[5].SetActive(true);
                parStar[6].SetActive(true);
            }
            laserPointerhitPoint = hit.point;
            ShowLaser(hit);
        }
        else
        {
            laserPointer.SetActive(false);
        }

        //선택한 별자리로 이동
        if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "front")
        {
            player.transform.position = new Vector3(0.48f, 0.52f, 0.14f);
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "front1")
        {
            player.transform.position = new Vector3(0.48f, 0.52f, 0.14f);
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "front2")
        {
            player.transform.position = new Vector3(0.48f, 0.52f, 0.14f);
        }
        else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "front3")
        {
            player.transform.position = new Vector3(0.48f, 0.52f, 0.14f);
        }

        //별 모형 삭제
        if (desStar[0] == true && desStar[1] == true && desStar[2] == true && desStar[3] == true && desStar[4] == true && desStar[5] == true && desStar[6] == true && desStar[7] == true && desStar[8] == true && desStar[9] == true && desStar[10] == true)
        {
            for (int j = 0; j < 10; j++)
            {
                Destroy(star[j]);
            }
        }
    }

    //선 그리기
    void drawLine(int num)
    {
        line[num].transform.localScale += new Vector3(0, 1.0f, 0) * Time.deltaTime * speed;
        speed = 10.0f;
    }

    private void ShowLaser(RaycastHit hit)
    {
        laserPointer.SetActive(true);
        laserPointer.transform.position = Vector3.Lerp(controllerPose.transform.position, laserPointerhitPoint, 0.5f);
        laserPointerTransform.LookAt(laserPointerhitPoint);
        laserPointerTransform.localScale = new Vector3(laserPointerTransform.localScale.x,
                                                       laserPointerTransform.localScale.y,
                                                       hit.distance);
    }

    
}
