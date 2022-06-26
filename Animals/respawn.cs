using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject animal_1_Prefab;
    private Vector3 animal_1_Pos;
    public GameObject animal_2_Prefab;
    private Vector3 animal_2_Pos;
    public GameObject animal_3_Prefab;
    private Vector3 animal_3_Pos;
    public GameObject animal_4_Prefab;
    private Vector3 animal_4_Pos;
    public GameObject animal_5_Prefab;
    private Vector3 animal_5_Pos;
    public GameObject animal_6_Prefab;
    private Vector3 animal_6_Pos;
    public GameObject animal_7_Prefab;
    private Vector3 animal_7_Pos;
    public GameObject animal_8_Prefab;
    private Vector3 animal_8_Pos;
    public GameObject animal_9_Prefab;
    private Vector3 animal_9_Pos;
    public GameObject animal_10_Prefab;
    private Vector3 animal_10_Pos;
    public GameObject animal_11_Prefab;
    private Vector3 animal_11_Pos;
    public GameObject animal_12_Prefab;
    private Vector3 animal_12_Pos;

    // Start is called before the first frame update
    void Start()
    {
        animal_1_Pos = animal_1_Prefab.transform.position;
        animal_2_Pos = animal_2_Prefab.transform.position;
        animal_3_Pos = animal_3_Prefab.transform.position;
        animal_4_Pos = animal_4_Prefab.transform.position;
        animal_5_Pos = animal_5_Prefab.transform.position;
        animal_6_Pos = animal_6_Prefab.transform.position;
        animal_7_Pos = animal_7_Prefab.transform.position;
        animal_8_Pos = animal_8_Prefab.transform.position;
        animal_9_Pos = animal_9_Prefab.transform.position;
        animal_10_Pos = animal_10_Prefab.transform.position;
        animal_11_Pos = animal_11_Prefab.transform.position;
        animal_12_Pos = animal_12_Prefab.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject CollObject = other.gameObject;

        if(other.gameObject.name == "Beagle")
        {
            Debug.Log("aa");
            other.transform.position = animal_1_Pos;
            //Destroy(other.gameObject);
            //Instantiate(animal_1_Prefab, animal_1_Pos.position, animal_1_Pos.rotation);
            CollObject = null;
        }
        else if(other.gameObject.name == "Bird")
        {
            other.transform.position = animal_2_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Cat")
        {
            other.transform.position = animal_3_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Chick")
        {
            other.transform.position = animal_4_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Elephant")
        {
            other.transform.position = animal_5_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Lizard")
        {
            other.transform.position = animal_6_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Penguin")
        {
            other.transform.position = animal_7_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Pig")
        {
            other.transform.position = animal_8_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Rhinoceros")
        {
            other.transform.position = animal_9_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Spider")
        {
            other.transform.position = animal_10_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Turtle")
        {
            other.transform.position = animal_11_Pos;
            CollObject = null;
        }
        else if (other.gameObject.name == "Zebra")
        {
            other.transform.position = animal_12_Pos;
            CollObject = null;
        }
    }
}
