using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_Clean : MonoBehaviour
{
    public GameObject[] Dust = new GameObject[4];
    //public bool[] is_destroyed = new bool[4]; 

    public bool is_empty_0 = false;
    public bool is_empty_1 = false;
    public bool is_empty_2 = false;
    public bool is_empty_3 = false;
    public bool sum_empty = false;

    void Update()
    {
        /*if(is_destroyed[0])
        {
            is_empty_0 = true;
        }
        if (is_destroyed[1])
        {
            is_empty_1 = true;
        }
        if (is_destroyed[2])
        {
            is_empty_2 = true;
        }
        if (is_destroyed[3])
        {
            is_empty_3 = true;
        }*/
        if (Dust[0] == null) 
        {
            is_empty_0 = true;
        }
        if (Dust[1] == null)
        {
            is_empty_1 = true;
        }
        if (Dust[2] == null)
        {
            is_empty_2 = true;
        }
        if (Dust[3] == null)
        {
            is_empty_3 = true;
        }

        if (is_empty_0 && is_empty_1 && is_empty_2 && is_empty_3)
        {
            sum_empty = true;
        }
    }
}

