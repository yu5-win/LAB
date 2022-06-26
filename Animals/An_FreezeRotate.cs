using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class An_FreezeRotate : MonoBehaviour
{
    public ControllerGrabObject cg;

    void Update()
    {
        /*if (cg.is_grabed)
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime);

            if(this.transform.rotation == Quaternion.Euler(0, -90, 0))
            {
                cg.is_grabed = false;
            }
        }*/
    }
}
