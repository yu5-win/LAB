using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_Color_Cube : MonoBehaviour
{
    Renderer CubeColor;
    void Start()
    {
        CubeColor = gameObject.GetComponent<Renderer>();
        spawnCube();
    }

    // Update is called once per frame

    void spawnCube()
    {
        CubeColor.material.color = new Color((int)(Random.Range(0, 256)) / 255f, (int)(Random.Range(0, 256)) / 255f, (int)(Random.Range(0, 256)) / 255f);
    }
}
