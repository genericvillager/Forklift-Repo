using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekTwoExersize : MonoBehaviour
{
    [SerializeField] private float x, y;

    [SerializeField] private float lastMagnitude;

    float Magnitude
    {
        get 
        {
            lastMagnitude = Mathf.Sqrt(SqMagnitude);

            return lastMagnitude;
        }
        set
        {
            float mag = Magnitude;

            float magX = x / mag;
            float magY = y / mag;

            x = magX * value;
            y = magY * value;
        }
    }

    float SqMagnitude
    {
        get
        {
            return (x*x) + (y*y);
        }
        set
        {
            // Not needed for this
        }
    }

    float XAxisAngle
    {
        get 
        {
            return Mathf.Abs(Mathf.Rad2Deg*Mathf.Atan(y/x));
        }
        set 
        {
            // Not needed for this
        }
    }

    float YAxisAngle
    {
        get
        {
            return Mathf.Abs(Mathf.Rad2Deg* Mathf.Atan(x/y));
        }
        set
        {
            // Not needed for this   
        }
    }

    private void Start()
    {
        Debug.Log(Magnitude);
        Debug.Log(SqMagnitude);
        Debug.Log(XAxisAngle);
        Debug.Log(YAxisAngle);

        Debug.Log(lastMagnitude);

        Debug.Log(x);
        Debug.Log(y);
    }
}
