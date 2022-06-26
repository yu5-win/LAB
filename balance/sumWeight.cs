using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sumWeight : MonoBehaviour
{
    public measureWeight[] ob;
    public float[] mass = new float[5];
    public GameObject content;
    public GameObject title;
    public GameObject Check;
    public GameObject SuccessButton;
    public GameObject SuccessMessage;
    public Text fail;

 
    public void check()
    {
        if (ob[0].is_OnPosition && ob[1].is_OnPosition && ob[2].is_OnPosition && ob[3].is_OnPosition && ob[4].is_OnPosition)
        {

            for (int i = 0; i < 5; i++)
            {
                mass[i] = ob[i].GetObjectMass();
            }
            if (mass[0] > mass[1] && mass[1] > mass[2] && mass[2] > mass[3] && mass[3] > mass[4])
            {
                content.SetActive(false);
                title.SetActive(false);
                Check.SetActive(false);
                SuccessButton.SetActive(true);
                SuccessMessage.SetActive(true);

                PlayerPrefs.SetString("Emblem", "Balance");
                PlayerPrefs.Save();
                Debug.Log(PlayerPrefs.HasKey("Emblem"));
            }
            else
            {
                fail.text = "다시해보세요!";
                StartCoroutine("failedMsg");
            }
        }
        else
        {
            fail.text = "다시해보세요!";
            StartCoroutine("failedMsg");
        }
    }
    IEnumerator failedMsg()
    {
        yield return new WaitForSeconds(1.0f);
        fail.text = "확인해보기";

    }
}
