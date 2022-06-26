using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fossil_door_open : MonoBehaviour
{
    public ButtonCtrl Bctrl;
    public GameObject fossil_door;
    private bool is_moving = false;
    private bool is_open = false;
    private float moving_time = 0.0f;

    void Update()
    {
        if (Bctrl.start_fossil_door_open)
        {
            is_moving = true;

            if (is_moving && !is_open)
            {
                moving_time += 1.0f * Time.deltaTime;

                if (moving_time <= 2.65f)
                {
                    fossil_door.transform.Translate(Vector3.left * Time.deltaTime / 2);
                }
                else if (moving_time >= 2.65f)
                {
                    is_open = true;
                    is_moving = false;
                    moving_time = 0.0f;
                }
            }
        }

    }
}
