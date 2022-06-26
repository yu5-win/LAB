using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door_Open : MonoBehaviour
{
    public ButtonCtrl Bctrl;

    public GameObject ele_Door_L;
    public GameObject ele_Door_R;
    public GameObject CamRig;
    public GameObject Camera;
    public GameObject target_cam_Pos;

    private bool is_moving = false;
    public bool is_open = false;
    private float moving_time = 0.0f;

    void Update()
    {
        if (Bctrl.start_elevator_door_open)
        {
            CamRig.transform.position = target_cam_Pos.transform.position;
            Camera.transform.localPosition = new Vector3(0, 0, 0);
            is_moving = true;

            if (is_moving && !is_open)
            {
                moving_time += 1.0f * Time.deltaTime;

                if (moving_time <= 3.0f)
                {
                    ele_Door_L.transform.Translate(Vector3.right * Time.deltaTime / 3);
                    ele_Door_R.transform.Translate(Vector3.left * Time.deltaTime / 3);
                }
                else if (moving_time >= 3.0f)
                {
                    is_open = true;
                    is_moving = false;
                    moving_time = 0.0f;
                    Bctrl.start_elevator_door_open = false;
                }
            }
        }

    }

    public void CloseDoor()
    {
        is_moving = true;
        if(is_moving && is_open)
        {
            moving_time += 1.0f * Time.deltaTime;

            if(moving_time <= 3.0f)
            {
                ele_Door_L.transform.Translate(Vector3.left * Time.deltaTime / 3);
                ele_Door_R.transform.Translate(Vector3.right * Time.deltaTime / 3);
            }
            else if(moving_time >= 3.0f)
            {
                is_open = false;
                is_moving = false;
                moving_time = 0.0f;
            }
        }
    }
}
