using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YawVR;
/// <summary>
/// Sets the YawTracker's orientation based on the GameObject's orientation
/// </summary>
public class SimpleOrientationCopy : MonoBehaviour
{
    /*
       This script simply copies this gameObject's rotation, and sends it to the YawTracker
    */
    public Vector3 rotation;
    YawController yawController; // reference to 
    public InputGetter inputGetter;

    private float rotationForce = 0.08f;


    private void Start()
    {
        yawController = YawController.Instance();
        inputGetter = GetComponent<InputGetter>();
    }
    private void FixedUpdate()
    {
        rotation = new Vector3(0, 0, 0);


        for (int i = 0; i <= inputGetter.frameCount; i++)
        {

            rotation.x += (i - inputGetter.frameCount / 2) * (-inputGetter.prevAccelerationZ[i] - inputGetter.prevRotationX[i]);
            rotation.y += (i - inputGetter.frameCount / 2) * -inputGetter.prevRotationY[i];
            rotation.z += (i - inputGetter.frameCount / 2) * (-inputGetter.prevAccelerationX[i] - inputGetter.prevRotationZ[i]);

        }

        
        rotation.x += 30 * (-inputGetter.accelerationZ - inputGetter.rotationX);
        rotation.y += 30 * -inputGetter.rotationY;
        rotation.z += 30 * -(inputGetter.accelerationX - inputGetter.rotationZ);
        


        rotation *= rotationForce;
        

        yawController.TrackerObject.SetRotation(rotation);
    }
}
