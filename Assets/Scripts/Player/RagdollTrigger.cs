using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{

    
    public GameObject characterRig;
    public Animator characterAnimation;
    void Start()
    {
        getRagdollBits();
        ragdollOFF();
    }

    
    void Update()
    {
        
    }

    Collider[] ragdollsCollider;
    Rigidbody[] limbsRigidbodies;

    void getRagdollBits()
    {
        ragdollsCollider = characterRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = characterRig.GetComponentsInChildren<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            ragdollON();
        }
    }
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            ragdollON();
        }
    }
 void ragdollOFF()
    {
        // Deactivate Rigidbody and Colliders
        foreach (Collider collider in ragdollsCollider)
        {
            collider.enabled = false;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        // ... other code ...
    }

    void ragdollON()
    {
        // Activate Rigidbody and Colliders
        foreach (Collider collider in ragdollsCollider)
        {
            collider.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        // ... other code ...
    }
}
