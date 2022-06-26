using Valve.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ImageRotate : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public GameObject Image;

    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            Image.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
        }
    }
}
