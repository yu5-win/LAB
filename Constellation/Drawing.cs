using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    //public Constellation_ControllerGrabObject ccg_L;
    public Constellation_ControllerGrabObject ccg_R;

    void OnTriggerEnter(Collider other)
    {
        /*
        ccg_L.speed = 0.0f;
        ccg_R.speed = 0.0f;
        ccg_L.a = false;
        ccg_L.b = false;
        ccg_L.c = false;
        ccg_L.d = false;
        ccg_L.e = false;
        ccg_L.f = false;
        ccg_L.g = false;
        ccg_L.h = false;
        ccg_L.i = false;
        ccg_L.j = false;
        */

        ccg_R.a = false;
        ccg_R.b = false;
        ccg_R.c = false;
        ccg_R.d = false;
        ccg_R.e = false;
        ccg_R.f = false;
        ccg_R.g = false;
        ccg_R.h = false;
        ccg_R.i = false;
        ccg_R.j = false;
    }
}
