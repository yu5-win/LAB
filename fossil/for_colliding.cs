using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class for_colliding : MonoBehaviour
{
 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "fossil_picture")
        {
            SceneManager.LoadScene("fossil");
        }
        if(other.gameObject.name == "Ending_gate")
        {
            SceneManager.LoadScene("sc03");
        }
    }
}
