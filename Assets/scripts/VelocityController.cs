using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YawVR;

[RequireComponent(typeof(Rigidbody))]

/// <summary>
/// Sets the YawTracker's orientation based on the GameObject's speed
/// </summary>
public class VelocityController : MonoBehaviour
{
    /*
     This script uses the gameObjects's rigidbody's velocity to control the YawTracker
  */
    YawController yawController;

    private Rigidbody rigid;
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 change = new Vector3(0, 0, 0);
    public Vector3 body_vel = new Vector3(0,0,0);
    public bool collision = false;
    public Vector3 v;


    [SerializeField]
    private Vector3 multiplier = new Vector3(3f, 1f, -2f);
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        yawController = YawController.Instance();
        StartCoroutine(func());
    }



    private void FixedUpdate()
    {
        float x, y, z;
        body_vel = rigid.velocity;
        change = rigid.velocity - velocity;
        change.x = change.x *40;
        if (!collision)
            velocity = rigid.velocity;
        if ((change.x > 200 || change.x < -200) && !collision)
        {
            collision = true;
            StartCoroutine(func());
        }
        Vector3 vel = transform.InverseTransformVector(change);

        vel.x *= multiplier.x;
        vel.y *= multiplier.y;
        vel.z *= multiplier.z;

        v = new Vector3(vel.z, 0f, vel.x) + transform.localEulerAngles;

        if (!collision)
            yawController.TrackerObject.SetRotation(v);


    }

    IEnumerator func()
    {
        yawController.TrackerObject.SetRotation(new Vector3(-10000, v.y, v.x));
        yield return new WaitForSeconds(0.2f);
        yawController.TrackerObject.SetRotation(new Vector3(10000, v.y, v.x));
        yield return new WaitForSeconds(0.3f);

        collision = false;
    }


}
