using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class categorize1 : MonoBehaviour
{
    public GameObject[] answers = new GameObject[4];
    public bool answer_0 = false;
    public bool answer_1 = false;
    public bool answer_2 = false;
    public bool answer_3 = false;
    public bool is_full = false;
    public categorize cat = null;
    public GameObject content;
    public GameObject title;
    public GameObject Good;
    public GameObject FinButton;

    void Start()
    {
        cat = GameObject.Find("Q1").GetComponent<categorize>();
    }
    void Update()
    {
        if(answer_0 && answer_1 && answer_2 && answer_3)
        {
            is_full = true;
        }
        if(cat.is_full && is_full)
        {
            StartCoroutine(WaitSeconds());
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
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(0.5f);

        if(cat.is_full && is_full)
        {
            content.SetActive(false);
            title.SetActive(false);
            Good.SetActive(true);
            FinButton.SetActive(true);
            PlayerPrefs.SetString("Emblem", "Animal");
            PlayerPrefs.Save();
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
    }

}
