using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody myRigidbody;
    AudioSource myAudioSource;

    public float thrustVelocity = 1f;
    public float rotationVelocity = 1f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * thrustVelocity);

            if (!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
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
