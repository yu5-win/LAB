using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerGrabObject : MonoBehaviour
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

    public bool el_click;
    public bool is_grabed;
    //public ButtonCtrl bc;

    //public GameObject logo;
    //public GameObject silver;
    public bool buttonclick = false;

    void Start()
    {
        //레이저 포인터 프리팹 생성
        laserPointer = Instantiate(laserPointerPrefab);
        laserPointerTransform = laserPointer.transform;
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit,1000, laserPointerMask))
        {
            if(grabAction.GetLastStateDown(handType) && hit.transform.gameObject.tag == "Button")
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
            }
            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "AnimalDesk")
            {
                SceneManager.LoadScene("Animal");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "BalanceDesk")
            {
                SceneManager.LoadScene("Balance");
            }
            
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "UpButton")
            {
                el_click = true;
            }
            
            laserPointerhitPoint = hit.point;
            ShowLaser(hit);
            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "3grade")
            {
                PlayerPrefs.SetString("Level", "silver");
                PlayerPrefs.Save();
                SceneManager.LoadScene("sc03");
            }
            else if(grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "4grade")
            {
                PlayerPrefs.SetString("Level", "gold");
                PlayerPrefs.Save();
                SceneManager.LoadScene("sc03");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "5grade")
            {
                PlayerPrefs.SetString("Level", "dia");
                PlayerPrefs.Save();
                SceneManager.LoadScene("sc03");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "6grade")
            {
                PlayerPrefs.SetString("Level", "ruby");
                PlayerPrefs.Save();
                SceneManager.LoadScene("sc03");
            }

            //season
            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "spring")
            {
                PlayerPrefs.SetString("Season", "spring");
                PlayerPrefs.Save();
                SceneManager.LoadScene("00. Constellation");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "summer")
            {
                PlayerPrefs.SetString("Season", "summer");
                PlayerPrefs.Save();
                SceneManager.LoadScene("00. Constellation");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "autumn")
            {
                PlayerPrefs.SetString("Season", "autumn");
                PlayerPrefs.Save();
                SceneManager.LoadScene("00. Constellation");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "winter")
            {
                PlayerPrefs.SetString("Season", "winter");
                PlayerPrefs.Save();
                SceneManager.LoadScene("00. Constellation");
            }

            if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "Con_spring")
            {
                SceneManager.LoadScene("01. Spring");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "Con_summer")
            {
                SceneManager.LoadScene("02. Summer");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "Con_autumn")
            {
                SceneManager.LoadScene("03. Autumn");
            }
            else if (grabAction.GetLastStateDown(handType) && hit.transform.gameObject.name == "Con_winter")
            {
                SceneManager.LoadScene("04. Winter");
            }
        }
        else
        {
            laserPointer.SetActive(false);
        }

        //잡는 버튼을 누를 때
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }
        //잡는 버튼을 땔 때
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                is_grabed = true;
                ReleaseObject();
            }
        }
    }
    //충돌이 시작되는 순간
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌중일 때
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌이 끝나는 순간
    public void OnTriggerExit(Collider other)
    {
        if(!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }
    //충돌중인 객체로 설정
    private void SetCollidingObject(Collider col)
    {
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    //객체를 잡음
    private void GrabObject()
    {
        objectInHand = collidingObject; //잡은 객체로 설정
        collidingObject = null; //충돌 객체 해제

         var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
  
    }
    //FixedJoint => 객체들을 하나로 묶어 고정시켜줌
    //breakForce = > 조인트가 제거되도록 하기 위한 필요한 힘의 크기
    // breakTorque => 조인트가 제거되도록 하기 위해 필요한 토크

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    //객체를 놓음
    //contrllerPose.GetVeloecity() => 컨트롤러의 속도
    //controllerPose.GetAngularVelocity() => 컨트롤러의 각속도
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>()){
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity =
                controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity =
                controllerPose.GetAngularVelocity();
            //objectInHand.transform.rotation = Quaternion.Lerp(objectInHand.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);
        }
        objectInHand = null;
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
