using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public ButtonCtrl Bt;

    public SteamVR_Input_Sources handType; // 모두사용, 왼손, 오른손
    public SteamVR_Behaviour_Pose controllerPose; // 컨트롤러 정보
    public SteamVR_Action_Boolean teleportAction; // 텔레포트

    public GameObject laserPrefab; // 레이저 프리팹
    private GameObject laser;  // 레이저(인스턴스)
    private Transform laserTransform; // 레이저 트랜스폼
    private Vector3 hitPoint; //레이저가 부딪힌 부분

    public Transform cameraRigTransform; // cameraRig 트랜스폼
    public GameObject teleportReticlePrefab; // 텔레포트 레티클 프리팹
    private GameObject reticle;  // 레티클(인스턴스)
    private Transform teleportReticleTransform; //텔레포트 레티클 트랜스폼
    public Transform headTransform; //플레이어 머리(카메라) 트랜스폼
    public Vector3 teleportReticleOffset; //바닥 표면 위에 표시하기 위한 Offset 설정값
    public LayerMask teleportMask; // 텔레포트가 허용되는 레이어 마스크
    private bool shouldTeleport; //텔레포트가 가능한지 유무


    public GameObject MenuCanvas;
    private float down_elapsed = 0.0f;

    void Start()
    {   //레이저 프리팹 생성
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        //텔레포트 프리팹 생성
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }

    void Update()
    {
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;

            if(Physics.Raycast(controllerPose.transform.position, transform.forward,
                out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;
            }
        }
        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if(teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            Teleport();
        }

        if (!Bt.is_Menu_On && teleportAction.GetState(handType))
        {
            down_elapsed += 1.0f * Time.deltaTime;
            if (down_elapsed >= 2.0f)
            {
                MenuCanvas.SetActive(true);
                Bt.is_Menu_On = true;
                down_elapsed = 0.0f;
            }
        }
        else
        {
            down_elapsed = 0.0f;
        }
        if (!Bt.is_Menu_On)
        {
            MenuCanvas.SetActive(false);
        }

    }
    // 레이저 보여주기
    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laser.transform.position = Vector3.Lerp(controllerPose.transform.position,
            hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
    //텔레포트
    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }
}
