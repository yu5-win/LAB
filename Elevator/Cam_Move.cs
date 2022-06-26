using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Move : MonoBehaviour
{
    public Elevator_Door_Open EDO;

    public GameObject CamRig;
    public GameObject to_Pos;
    public GameObject season;

    public bool on_to_Position;

    private float rotate_time = 0.0f;

    void Update()
    {
        if (EDO.is_open)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, to_Pos.transform.position, Time.deltaTime / 2);
            if(to_Pos.transform.position.x - this.transform.position.x <= 0.5f)
            {
                rotate_time += 1.0f * Time.deltaTime;
                this.transform.position = to_Pos.transform.position;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to_Pos.transform.rotation, Time.deltaTime);
                if(rotate_time >= 2.0f)
                {
                    EDO.CloseDoor();
                    StartCoroutine(seasontime());
                }
            }
        }
    }
    IEnumerator seasontime()
    {
        yield return new WaitForSeconds(1.0f);
        season.SetActive(true);
    }
}
