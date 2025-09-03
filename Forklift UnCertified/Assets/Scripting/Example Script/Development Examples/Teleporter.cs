using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform targetLocation;

    public void TeleportPlayer()
    {
        FindObjectOfType<PlayerMovement>().transform.position = targetLocation.transform.position;
    }
}
