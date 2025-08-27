using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleBox : Box
{
    [SerializeField] private int teleDist;

    public LayerMask teleMask;

    public override void PutDown()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, teleDist + 0.5f, teleMask))
        {
            transform.position = transform.position + (transform.forward * (hit.distance - 0.5f));
        }
        else
        {
            transform.position = transform.position + (transform.forward * teleDist);
        }

        base.PutDown();
    }
}
