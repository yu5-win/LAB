using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixbody : MonoBehaviour
{
    //삽에다가 넣을 것 
    //삽 = usegravity = true, 컨트롤러 = is_kinematic = true

    //public modify_Terrain mt_L;
    public modify_Terrain mt_R;

    public bool is_connected = false;
    public FixedJoint fj;
    public Transform dust_effect;
    private GameObject controller;
    private Transform controllerTr;

    private Animation anim;
    //public GameObject shovel_fix;

    private void Start()
    {
        //anim = GetComponent<Animation>();
    }

    private void Update()
    {
        /*RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.left);

        Debug.DrawRay(this.transform.position, fwd * 10, Color.green);
        if(Physics.Raycast(this.transform.position, fwd, out hit, 10) && hit.collider.gameObject.name == "Plane")
        {
            line.SetActive(true);
            line.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(dust_effect, hit.point, Quaternion.Euler(0, 0, 0));
                anim.Blend("shovel_move_up");
            }
            
        }*/
        if (is_connected &&!mt_R.is_grab1)
        {
            //Destroy(fj);
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            is_connected = false;
        }
        if (is_connected && !mt_R.is_grab1)
        {
            //anim.Play("shovel_move");
            //anim.Play("shovel_move_up");
            //anim.Blend("shovel_move_up");
        }
        else
        {
            //anim.Stop("shovel_move_up");
        }
        if(mt_R.is_grab1 && !is_connected)
        {
            //transform.SetParent(shovel_fix.transform);
            /*this.gameObject.transform.position = new Vector3(controllerTr.transform.position.x + 0.3f, controllerTr.transform.position.y-0.2f, controllerTr.transform.position.z) ;
            this.gameObject.transform.rotation = Quaternion.Euler(controllerTr.transform.rotation.x-50, controllerTr.transform.rotation.y+90, controllerTr.transform.rotation.z);//Quaternion.Euler(controllerTr.transform.rotation.x-50, controllerTr.transform.rotation.y+90, controllerTr.transform.rotation.z);
            fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = controller.GetComponent<Rigidbody>();*/
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            is_connected = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag =="Ctrller")
        {
            controller = other.gameObject;
            controllerTr = controller.GetComponent<Transform>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ctrller")
        {
            controller = null;
        }
    }
}
