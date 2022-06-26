using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public GameObject[] Info = new GameObject[3];
    public GameObject[] fossil = new GameObject[3];
    public GameObject[] Check = new GameObject[3];
    public GameObject[] CheckBox = new GameObject[3];
    private GameObject[] CollectedOb = new GameObject[3];

    public GameObject Ending_Stuff;
    public GameObject clear;
    public GameObject Ending_Terrain;

    public is_Clean Fish;
    public is_Clean Ammonite;
    public is_Clean Trilobite;

    private int Info_Index = 0;

    void Update()
    {
        if (Fish.sum_empty)
        {
            fossil[0].gameObject.layer = 8;
        }
        if (Ammonite.sum_empty)
        {
            fossil[1].gameObject.layer = 8;
        }
        if (Trilobite.sum_empty)
        {
            fossil[2].gameObject.layer = 8;
        }

    }
    public void OnDescription(GameObject hit)
    {
        for(Info_Index = 0; Info_Index < fossil.GetLength(0); Info_Index++)
        {
            if (hit.Equals(fossil[Info_Index]))
            {
                Info[Info_Index].SetActive(true);
                CheckBox[Info_Index].SetActive(false);
                Check[Info_Index].SetActive(true);
                CollectedOb[Info_Index] = hit;
                CheckFull();
                StartCoroutine("MsgDelay", Info_Index);
            }
        }
    }
    IEnumerator MsgDelay(int Info_Index)
    {
        yield return new WaitForSeconds(3.0f);
        Info[Info_Index].SetActive(false);
    }
    void CheckFull()
    {
        for(int i = 0; i < fossil.GetLength(0); i++)
        {
            if (CollectedOb[i])
            { 
            }
            else
            {
                return;
            }
        }
        StartCoroutine("clearDelay");
    }
    IEnumerator clearDelay()
    {
        yield return new WaitForSeconds(3.0f);
        clear.SetActive(true);
        Ending_Stuff.SetActive(true);
        PlayerPrefs.SetString("Emblem", "Fossil");
        PlayerPrefs.Save();
        StartCoroutine("clearall");
    }
    IEnumerator clearall()
    {
        yield return new WaitForSeconds(2.0f);
        clear.SetActive(false);
        Ending_Terrain.gameObject.layer = 9;
    }
}
