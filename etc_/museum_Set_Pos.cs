using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class museum_Set_Pos : MonoBehaviour
{
    public ButtonCtrl Bt;

    public GameObject InfoUI;

    public GameObject CamRig;
    public GameObject animal_Pos;
    public GameObject balance_Pos;
    public GameObject fossil_Pos;
    public GameObject star_Pos;
    void Start()
    {
        if (PlayerPrefs.GetString("achievements") == "Animal")
        {
            CamRig.transform.position = animal_Pos.transform.position;
            PlayerPrefs.DeleteKey("achievements");
        }
        else if (PlayerPrefs.GetString("achievements") == "Balance")
        {
            CamRig.transform.position = balance_Pos.transform.position;
            PlayerPrefs.DeleteKey("achievements");
        }
        else if (PlayerPrefs.GetString("achievements") == "fossil")
        {
            CamRig.transform.position = fossil_Pos.transform.position;
            PlayerPrefs.DeleteKey("achievements");
        }
        else if (PlayerPrefs.GetString("achievements") == "01.Spring")
        {
            CamRig.transform.position = star_Pos.transform.position;
            PlayerPrefs.DeleteKey("achievements");
        }
        else if (PlayerPrefs.GetString("achievements") == "normal")
        {
            CamRig.transform.position = new Vector3(0, 0, 0);
            PlayerPrefs.DeleteKey("achievements");
        }
    }
    void Update()
    {
        if (Bt.OnUI)
        {
            InfoUI.SetActive(true);
        }
    }
}
