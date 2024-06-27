using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public SimpleOrientationCopy simpleOrientationCopy;
    public PlayerMovement playerMovement;
    Vector3 defaultLastFrame, yawLastFrame;


    void Start()
    {
        defaultLastFrame = gameObject.transform.rotation.eulerAngles;
        yawLastFrame = simpleOrientationCopy.rotation;
    }

    
    void Update()
    {
        defaultLastFrame += yawLastFrame;
        Vector3 defaultCurrentFrame = defaultLastFrame - simpleOrientationCopy.rotation;
        transform.Rotate(defaultCurrentFrame);
        defaultLastFrame = gameObject.transform.rotation.eulerAngles;
        yawLastFrame = simpleOrientationCopy.rotation;
    }
}
