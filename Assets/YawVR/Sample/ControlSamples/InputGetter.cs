using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGetter : MonoBehaviour
{


    [Header("Input")]
    public float accelerationX, accelerationY, accelerationZ;
    public float rotationX, rotationY, rotationZ;

    public List<float> prevAccelerationX, prevAccelerationY, prevAccelerationZ, prevRotationX, prevRotationY, prevRotationZ;

    private int frameCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= frameCount; i++)
        {
            prevAccelerationX.Add(0f);
            prevAccelerationY.Add(0f);
            prevAccelerationZ.Add(0f);
            prevRotationX.Add(0f);
            prevRotationY.Add(0f);
            prevRotationZ.Add(0f);
        }
    }



    void inputs()
    {
        prevAccelerationX.RemoveAt(0);
        prevAccelerationX.Add(accelerationX);
        prevAccelerationY.RemoveAt(0);
        prevAccelerationY.Add(accelerationY);
        prevAccelerationZ.RemoveAt(0);
        prevAccelerationZ.Add(accelerationZ);

        prevRotationX.RemoveAt(0);
        prevRotationX.Add(rotationX);
        prevRotationY.RemoveAt(0);
        prevRotationY.Add(rotationY);
        prevRotationZ.RemoveAt(0);
        prevRotationZ.Add(rotationZ);

        

        bool movementKeyboard = false;
        bool rotationKeyboard = false;


        //force

        ////////keyboard controls/////////
        if (movementKeyboard)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                accelerationX = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                accelerationX = -1;
            }
            else
            {
                accelerationX = 0;
            }
            if (Input.GetKey(KeyCode.W))
            {
                accelerationY = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                accelerationY = -1;
            }
            else
            {
                accelerationY = 0;
            }
            if (Input.GetKey(KeyCode.E))
            {
                accelerationZ = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                accelerationZ = -1;
            }
            else
            {
                accelerationZ = 0;
            }
        }
        else
        {
            accelerationX = -Input.GetAxisRaw("accX");
            accelerationY = -Input.GetAxisRaw("accY");
            accelerationZ = -Input.GetAxisRaw("accZ");
        }


        //rotate

        if (rotationKeyboard)
        {
            if (Input.GetKey(KeyCode.R))
            {
                rotationX = 1;
            }
            else if (Input.GetKey(KeyCode.F))
            {
                rotationX = -1;
            }
            else
            {
                rotationX = 0;
            }
            if (Input.GetKey(KeyCode.T))
            {
                rotationY = 1;
            }
            else if (Input.GetKey(KeyCode.G))
            {
                rotationY = -1;
            }
            else
            {
                rotationY = 0;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                rotationZ = 1;
            }
            else if (Input.GetKey(KeyCode.H))
            {
                rotationZ = -1;
            }
            else
            {
                rotationZ = 0;
            }
        }
        else
        {
            rotationX = Input.GetAxisRaw("rotateX");
            rotationY = Input.GetAxisRaw("rotateY");
            rotationZ = Input.GetAxisRaw("rotateZ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputs();
    }
}
