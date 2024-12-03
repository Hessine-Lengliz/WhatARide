using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class permittedArea : MonoBehaviour
{private bool onlyOne = false;
 void OnTriggerEnter(Collider other)
 {
     if (!onlyOne) { 
     // Check if the exiting collider belongs to the player
     if (other.CompareTag("Player"))
     {
         
         GameObject pigManager = GameObject.Find("pigManager");

         // Check if the pigManager GameObject was found
         if (pigManager != null)
         {
             // Get the piggySrc script attached to the pigManager GameObject
             piggyScr pigManagerScript = pigManager.GetComponent<piggyScr>();

             // Check if the piggySrc script was found
             if (pigManagerScript != null)
             {
                 // Set the isLeft variable to true
                 pigManagerScript.isLeft = true;

                 // Optionally, you can print a message to confirm the change
                
             }
             else
             {
                 Debug.LogError("piggySrc script not found on pigManager GameObject.");
             }
         }
         else
         {
             Debug.LogError("pigManager GameObject not found in the scene.");
         }
     }
 onlyOne = true;
 }
 }
}
