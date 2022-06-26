using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class categorize : MonoBehaviour
{
    public GameObject[] answers = new GameObject[8];
    bool answer_0 = false;
    bool answer_1 = false;
    bool answer_2 = false;
    bool answer_3 = false;
    bool answer_4 = false;
    bool answer_5 = false;
    bool answer_6 = false;
    bool answer_7 = false;
    public bool is_full = false;

    void Update()
    {
        if(answer_0 && answer_1 && answer_2 && answer_3 && answer_4 && answer_5 && answer_6 && answer_7)
        {
            is_full = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == answers[0])
        {
            answer_0 = true;
        }
        else if(other.gameObject == answers[1])
        {
            answer_1 = true;
        }
        else if (other.gameObject == answers[2])
        {
            answer_2 = true;
        }
        else if (other.gameObject == answers[3])
        {
            answer_3 = true;
        }
        else if (other.gameObject == answers[4])
        {
            answer_4 = true;
        }
        else if (other.gameObject == answers[5])
        {
            answer_5 = true;
        }
        else if (other.gameObject == answers[6])
        {
            answer_6 = true;
        }
        else if (other.gameObject == answers[7])
        {
            answer_7 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == answers[0])
        {
            answer_0 = false;
        }
        else if (other.gameObject == answers[1])
        {
            answer_1 = false;
        }
        else if (other.gameObject == answers[2])
        {
            answer_2 = false;
        }
        else if (other.gameObject == answers[3])
        {
            answer_3 = false;
        }
        else if (other.gameObject == answers[4])
        {
            answer_4 = false;
        }
        else if (other.gameObject == answers[5])
        {
            answer_5 = false;
        }
        else if (other.gameObject == answers[6])
        {
            answer_6 = false;
        }
        else if (other.gameObject == answers[7])
        {
            answer_7 = false;
        }

    }
}
