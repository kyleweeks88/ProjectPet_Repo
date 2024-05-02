using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody myRigidbody;
    bool isRotating;
    public float thrustForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * thrustForce, ForceMode.Force); ;
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isRotating = true;
            Debug.Log("Rotate Left");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate Right");
        }
    }
}
