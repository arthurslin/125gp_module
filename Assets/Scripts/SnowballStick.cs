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
        if (!isStuck)
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null && otherRb != collision.gameObject.CompareTag("Player"))
            {
                transform.parent = collision.transform;
                rb.isKinematic = true;
                isStuck = true;
            }
        }
    }
}
