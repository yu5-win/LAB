using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActOrNot : MonoBehaviour
{
    public ButtonCtrl bt;
    public GameObject elevator;

    public GameObject Fossil_scene_stuff; // 골드에서 active
    public GameObject deActive_Wall_original; // 골드에서 deactive
    public GameObject Elevator_stuff;
    public GameObject deActive_Wall_original_el;
    public GameObject Animal_desk;
    public GameObject Balances_desk;

    public GameObject animal;
    public GameObject balance;
    public GameObject fossil;
    public GameObject star;
    //season
    public GameObject Spring;
    public GameObject Summer;
    public GameObject Autumn;
    public GameObject Winter;

    void Start()
    {
        //level
        if (PlayerPrefs.GetString("Level") == "gold")
        {
            Fossil_scene_stuff.SetActive(true);
            deActive_Wall_original.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Level") == "ruby")
        {
            Elevator_stuff.SetActive(true);
            deActive_Wall_original_el.SetActive(false);
        }
        else if(PlayerPrefs.GetString("Level") == "silver")
        {
            Animal_desk.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Level") == "dia")
        {
            Balances_desk.SetActive(true);
        }
        else
        {
            Balances_desk.SetActive(false);
            Animal_desk.SetActive(false);
            Fossil_scene_stuff.SetActive(false);
            deActive_Wall_original.SetActive(true);
            Elevator_stuff.SetActive(false);
            deActive_Wall_original_el.SetActive(true);
        }
        if (PlayerPrefs.GetString("Emblem") == "Animal"){
            animal.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Emblem") == "Balance")
        {
            balance.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Emblem") == "Fossil")
        {
            fossil.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Emblem") == "Star")
        {
            star.SetActive(true);
        }
        else
        {
            animal.SetActive(false);
            balance.SetActive(false);
            fossil.SetActive(false);
            star.SetActive(false);
        }

        //season
        if (PlayerPrefs.GetString("Season") == "spring")
        {
            Spring.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Season") == "summer")
        {
            Summer.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Season") == "autumn")
        {
            Autumn.SetActive(true);
        }
        else if (PlayerPrefs.GetString("Season") == "winter")
        {
            Winter.SetActive(true);
        }
        else
        {
            Spring.SetActive(false);
            Summer.SetActive(false);
            Autumn.SetActive(false);
            Winter.SetActive(false);
        }



    }

}
