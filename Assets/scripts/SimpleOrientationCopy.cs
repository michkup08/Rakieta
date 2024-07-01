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
    public Vector3 rotationDel;
    YawController yawController; // reference to 
    public InputGetter inputGetter;

    public float rotationForceX;
    public float rotationForceY;
    public float rotationForceZ;

    private void Start()
    {
        yawController = YawController.Instance();
        inputGetter = GetComponent<InputGetter>();
        rotation = new Vector3(0, 0, 0);
        rotationDel = new Vector3(0, 0, 0);
        rotationForceX = 4f;
        rotationForceY = 20f;
        rotationForceZ = 15f;
    }
    private void FixedUpdate()
    {
        //for (int i = 0; i <= inputGetter.frameCount; i++)
        //{

        //    rotation.x += (i - inputGetter.frameCount / 2) * (-inputGetter.prevAccelerationZ[i] - inputGetter.prevRotationX[i]);
        //    rotation.y += (i - inputGetter.frameCount / 2) * -inputGetter.prevRotationY[i];
        //    rotation.z += (i - inputGetter.frameCount / 2) * (-inputGetter.prevAccelerationX[i] - inputGetter.prevRotationZ[i]);

        //}
  
        //rotation.x += 30 * (-inputGetter.accelerationZ - inputGetter.rotationX);
        //rotation.y += 30 * -inputGetter.rotationY;
        //rotation.z += 30 * -(inputGetter.accelerationX - inputGetter.rotationZ);

        rotationDel.x += rotationForceX * (inputGetter.prevAccelerationZ[0] - inputGetter.prevRotationX[0]);
        rotationDel.y += rotationForceY * -inputGetter.prevRotationY[0];
        rotationDel.z += rotationForceZ * (-inputGetter.prevAccelerationX[0] - inputGetter.prevRotationZ[0]);

        rotationDel.x -= rotationForceX * (inputGetter.prevAccelerationZ[1] - inputGetter.prevRotationX[1]);
        rotationDel.y -= rotationForceY * -inputGetter.prevRotationY[1];
        rotationDel.z -= rotationForceZ * (-inputGetter.prevAccelerationX[1] - inputGetter.prevRotationZ[1]);

        //if (rotationDel.x > 0)
        //    rotationDel.x *= 0.7f; 

        rotationDel.x = loggg(rotationDel.x);
        rotationDel.y = loggg(rotationDel.y);
        rotationDel.z = loggg(rotationDel.z);

        rotation += rotationDel;

        rotation *= 0.99f;
        
        yawController.TrackerObject.SetRotation(rotation);
    }

    private float loggg(float x)
    {
        int sign = (x > 0 ? 1 : -1);
        x = Mathf.Abs(x);

        return Mathf.Log(x + 1) * sign;
    }
}
