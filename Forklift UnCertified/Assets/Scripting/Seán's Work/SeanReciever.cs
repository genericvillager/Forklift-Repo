using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SeanReciever : MonoBehaviour
{
    private Rigidbody rb;

    public Vector3 myVelocity;

    public int moveSpeed; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
    }

    public void VelocityVoid()
    {
        rb.velocity = myVelocity;
    }
}
