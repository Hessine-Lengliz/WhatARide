using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrapChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger, print a debug message
            Debug.Log("Player entered the trigger!");

            // Get the parent GameObject
            GameObject parentObject = transform.parent.gameObject;

            // Get the script component on the parent GameObject
            trapSpikeGrate myParentScript = parentObject.GetComponentInParent<trapSpikeGrate>();

            // Check if the script component is not null
            if (myParentScript != null)
            {
                // Access the boolean variable directly and set its value
                myParentScript.spikeTrigger = true;
            }
        }
    }

}
    