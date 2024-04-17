using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    [Header("Input")]
    public float accX, accY, accZ;
    public float rotateX, rotateY, rotateZ;
    [Header("Variables")]
    public float movForce;
    public float rotateSpeed;
    public Vector3 movement, rotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }
    void inputs()
    {
        //force

        ////////keyboard controls/////////
        /*
        if(Input.GetKey(KeyCode.Q))
        {
            accX = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            accX = -1;
        }
        else
        {
            accX = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            accY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            accY = -1;
        }
        else
        {
            accY = 0;
        }
        if (Input.GetKey(KeyCode.E))
        {
            accZ = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            accZ = -1;
        }
        else
        {
            accZ = 0;
        }


        //rotate
        
        if (Input.GetKey(KeyCode.R))
        {
            rotateX = 1;
        }
        else if (Input.GetKey(KeyCode.F))
        {
            rotateX = -1;
        }
        else
        {
            rotateX = 0;
        }
        if (Input.GetKey(KeyCode.T))
        {
            rotateY = 1;
        }
        else if (Input.GetKey(KeyCode.G))
        {
            rotateY = -1;
        }
        else
        {
            rotateY = 0;
        }
        if (Input.GetKey(KeyCode.Y))
        {
            rotateZ = 1;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            rotateZ = -1;
        }
        else
        {
            rotateZ = 0;
        }*/
        


        ////////joystick controls////////
        
        accX = Input.GetAxisRaw("accX");
        accY = Input.GetAxisRaw("accY");
        accZ = Input.GetAxisRaw("accZ");
        rotateX = Input.GetAxisRaw("rotateX");
        rotateY = Input.GetAxisRaw("rotateY");
        rotateZ = Input.GetAxisRaw("rotateZ");
    }

    void movementUpdate()
    {
        movement = (accX * gameObject.transform.right + accY * gameObject.transform.up + accZ * gameObject.transform.forward) * movForce;
        rotation += new Vector3(rotateX, rotateY, rotateZ) * rotateSpeed ;
        rotation *= (float)Math.Pow(0.95f, 60 * Time.deltaTime);

    }

    void movementExecute()
    {
        rigidbody.AddForce(movement, ForceMode.Acceleration);
        rigidbody.velocity *= (float) Math.Pow(0.99f, 60 * Time.deltaTime);
        
        
        transform.Rotate(rotation);
    }


    // Update is called once per frame
    void Update()
    {
        inputs();
        movementUpdate();
        movementExecute();
    }

}
