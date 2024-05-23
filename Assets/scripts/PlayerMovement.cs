using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    [Header("Variables")]
    public float movForce;
    public float rotateSpeed;
    public Vector3 movement, rotation;

    public InputGetter inputGetter;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        inputGetter = GetComponent<InputGetter>();
    }
    

    void movementUpdate()
    {


        movement = (inputGetter.accelerationX * gameObject.transform.right + inputGetter.accelerationY * gameObject.transform.up + inputGetter.accelerationZ * gameObject.transform.forward) * movForce * Time.deltaTime;
        rotation += new Vector3(inputGetter.rotationX, inputGetter.rotationY, inputGetter.rotationZ) * rotateSpeed * Time.deltaTime;
        rotation *= (float)Math.Pow(0.95f, 60 * Time.deltaTime);

    }

    void movementExecute()
    {
        rigidbody.AddForce(movement, ForceMode.Acceleration);
        rigidbody.velocity *= (float) Math.Pow(0.95f, 60 * Time.deltaTime);
        
        
        transform.Rotate(rotation);
    }


    // Update is called once per frame
    void Update()
    {
        movementUpdate();
        movementExecute();
    }

}
