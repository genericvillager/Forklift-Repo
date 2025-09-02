using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchrodingerBox : Box
{
    private Renderer schrodingerRenderer;

    [SerializeField] private Transform destination;

    [SerializeField] private bool canMove;

    [SerializeField] private float seekSpeed;

    private void Awake()
    {
        schrodingerRenderer = GetComponent<Renderer>();

        if (destination == null)
        {
            destination = GameObject.FindGameObjectWithTag("Schrodinger's Target").transform;
        }
    }

    private void Start()
    {
        canMove = false;
        StartCoroutine(CanTryMove(1f));
    }

    private void Update()
    {
        /*
        if (canMove)
        {
            Debug.Log("Can Move");
        }

        if (!schrodingerRenderer.isVisible)
        {
            Debug.Log("Not Visible");
        }
        else
        {
            Debug.Log("Visible");
        }

        if (!AtDestination())
        {
            Debug.Log("Not At Destination");
        }
        */

        if (canMove && !schrodingerRenderer.isVisible && !AtDestination())
            MoveToDestination();
    }

    public override void PickUp()
    {
        canMove = false;

        base.PickUp();
    }

    public override void PutDown()
    {
        canMove = true;

        base.PutDown();
    }

    private void MoveToDestination()
    {
        Debug.Log("Moving to Destination");
        transform.position = Vector3.MoveTowards(transform.position, destination.position, seekSpeed * Time.fixedDeltaTime);
        //StartCoroutine(MoveAfterDelay(1f));
    }

    IEnumerator MoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Moving...");
        transform.position = Vector3.MoveTowards(transform.position, destination.position, seekSpeed * Time.fixedDeltaTime);
    }

    IEnumerator CanTryMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    private bool AtDestination()
    {
        if (Vector3.Distance(transform.position, destination.position) < 0.001f)
        {
            Debug.Log("At Destination");
            canMove = false;
            return true;
        }
        else
        {
            canMove = true;
            return false;
        }
    }
}
