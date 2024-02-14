using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObject : MonoBehaviour
{
    private bool isStuck = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (!isStuck)
        {
            // Check if the collision object has a Rigidbody
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                // Stick to the collided object by making it a child
                transform.parent = collision.transform;
                rb.isKinematic = true;

                isStuck = true;
            }
        }
    }
}
