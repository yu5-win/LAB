using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac : MonoBehaviour
{
    private SphereCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<SphereCollider>();
        coll.radius = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
