using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public bool start_fossil_door_open = false;
    public bool start_elevator_door_open = false;
    public bool OnUI = false;
    public bool is_Menu_On = false;

    public void Home()
    {
        SceneManager.LoadScene("sc01");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void LevelScene()
    {
        SceneManager.LoadScene("sc02");
    }
    public void BackToLab()
    {
        SceneManager.LoadScene("sc03");
    }
    public void FossilDoorOpen()
    {
        start_fossil_door_open = true;
    }
    public void ElevatorDoorOpen()
    {
        start_elevator_door_open = true;
    }
    public void OnInfoUI()
    {
        OnUI = true;
    }
    public void Museum()
    {
        SceneManager.LoadScene("museum");
    }
    public void MenuOff()
    {
        is_Menu_On = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void reward()
    {
        if(SceneManager.GetActiveScene().name == "Animal")
        {
            PlayerPrefs.SetString("achievements", "Animal");
            PlayerPrefs.Save();
            SceneManager.LoadScene("museum");
        }
        else if(SceneManager.GetActiveScene().name == "Balance")
        {
            PlayerPrefs.SetString("achievements", "Balance");
            PlayerPrefs.Save();
            SceneManager.LoadScene("museum");
        }
        else if (SceneManager.GetActiveScene().name == "fossil")
        {
            PlayerPrefs.SetString("achievements", "fossil");
            PlayerPrefs.Save();
            SceneManager.LoadScene("museum");
        }
        else if (SceneManager.GetActiveScene().name == "00.Constellation" || SceneManager.GetActiveScene().name == "01.Spring" || SceneManager.GetActiveScene().name == "02.Summer" || SceneManager.GetActiveScene().name == "03.Autumn" || SceneManager.GetActiveScene().name == "04.Winter")
        {
            PlayerPrefs.SetString("achievements", "01.Spring");
            PlayerPrefs.Save();
            SceneManager.LoadScene("museum");
        }
        else
        {
            PlayerPrefs.SetString("achievements", "normal");
            PlayerPrefs.Save();
            SceneManager.LoadScene("museum");
        }
    }
}
