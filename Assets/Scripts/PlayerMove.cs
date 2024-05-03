using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody myRigidbody;
    public float thrustVelocity = 1f;
    public float rotationVelocity = 1f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * thrustVelocity);
        }
    }
    
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationVelocity);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationVelocity);
        }
    }

    void ApplyRotation(float _appliedVelocity)
    {
        transform.Rotate(Vector3.forward * _appliedVelocity);
    }
}
