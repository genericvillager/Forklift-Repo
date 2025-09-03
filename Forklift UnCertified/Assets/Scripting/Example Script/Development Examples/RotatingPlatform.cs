using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private void FixedUpdate()
    {
        transform.Rotate(transform.up, speed);
    }
}
