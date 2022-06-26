using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public GameObject target;

    public ButtonCtrl bc;
    //public DoorOpen dopen;

    //public Camera cam;
    public GameObject cam;
    public Vector3 targetPosition;

    public Transform to;

    private float turnspeed = 0.9f;

    public UnityEngine.UI.Image fade;
    float fades = 0f;

    public bool is_rotated = false;

    public GameObject season;
    // Start is called before the first frame update
    void Start()
    {
        if(target.gameObject != null)
        {
            // target 위치 찾기
            targetPosition.Set(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
    }
    public bool rotate;
    void Update()
    {
        if (fades == 1.0f)//dopen.is_open) // 문이 열림
        {
            // target 위치로 카메라 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * 0.28f); 
        }
        if (Mathf.Abs(this.transform.position.z - targetPosition.z) <= 0.4f) // 카메라가 target으로 이동 하면
        {
            //카메라 180도 회전
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to.transform.rotation, turnspeed * Time.deltaTime);
            
            if(this.transform.rotation == to.transform.rotation) //뒤돈거 확인
            {
                is_rotated = true;
            }
            if (is_rotated) // 뒤돈 후
            {
                rotate = true;
                //dopen.closeDoor(); // 문 닫힘
                is_rotated = false;
                StartCoroutine(seasontime()); // 계절씬 전환 이미지 활성화
            }

            if (this.transform.rotation == to.transform.rotation && fades < 1.0f)
            {
                //fade in
                fades += 0.01f;
                fade.color = new Color(0, 0, 0, fades);
            }
            else if(fades > 1.0f)
            {
                //씬 전환
                //SceneManager.LoadScene("Star");
                fades -= 0.01f;
                fade.color = new Color(0, 0, 0, fades);
            }
        }
    }
    IEnumerator seasontime()
    {
        yield return new WaitForSeconds(1.0f);
        season.SetActive(true);
    }
}