using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SeanSender : MonoBehaviour
{
    public SeanReciever reciever;

    private void Start()
    {
        if (reciever == null && !TryGetComponent<SeanReciever>(out reciever))
        {
            Debug.LogError("There is no reciever Assigned");
        }
    }

    private void Update()
    {
        reciever.myVelocity = new Vector3(Input.GetAxisRaw("Horizontal") * reciever.moveSpeed, Input.GetAxisRaw("Vertical") * reciever.moveSpeed, 0);

        reciever.VelocityVoid();
    }
}
