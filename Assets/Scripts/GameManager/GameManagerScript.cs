using UnityEngine;
using Cinemachine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform initialSpawnPoint;
    public CinemachineFreeLook freeLookCamera;
    public float delayBeforePlayerDeath = 1f;
    public float throwForce = 100f;
    private GameObject currentPlayer;
    

    private void Start()
    {
        InstantiatePlayer();
        
    }

    private void Update()
    {
        // You can add any other game manager logic here
    }

    private void InstantiatePlayer()
    {
        // Instantiate the player at the initial spawn point
           currentPlayer = Instantiate(playerPrefab, initialSpawnPoint.position, Quaternion.Euler(0f, 180f, 0f));

    // Find the child named "happy wheel character riding"
    Transform happyWheelCharacter = currentPlayer.transform.Find("happy wheel character riding");

    // Set the player as the follow and look at target for the Cinemachine FreeLook Camera
    UpdateFreeLookCameraTarget(happyWheelCharacter);
    }

    public void PlayerHitObstacle()
    {
        // Handle player death logic here (e.g., reset the level)
        

        StartCoroutine(DelayBeforePlayerDeath());
        SetNpcBehaviorIsLaugh(true);
    }

    private IEnumerator DelayBeforePlayerDeath()
    {
        // Handle player death logic here (e.g., apply additional force)
         ApplyAdditionalForce();

        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforePlayerDeath);

        // Reset the player to the initial spawn point after applying the force
        ResetPlayer();
    }

     private void ApplyAdditionalForce()
 {
//     // Apply an additional force to throw the player around
     Rigidbody playerRigidbody = currentPlayer.GetComponent<Rigidbody>();
     if (playerRigidbody != null)
     {
        
         Debug.Log("throwing");
        Vector3 throwDirection = Vector3.up; // You can replace Vector3.up with any desired direction

        

//         // Apply the force
         playerRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        
     }
     else
     {
         Debug.LogError("No Rigidbody component found on the player GameObject.");
     }
 }

    private void ResetPlayer()
    {
        // Destroy the existing player
        // if (currentPlayer != null)

        // {
        //     Destroy(currentPlayer);
        // }

        // // Instantiate the player at the initial spawn point
        // InstantiatePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateFreeLookCameraTarget(Transform target)
    {
        // Check if the Cinemachine FreeLook Camera is assigned
        if (freeLookCamera != null)
        {
            // Update the follow and look at targets to the new player
            freeLookCamera.Follow = target;
            freeLookCamera.LookAt = target;
        }
    }
    private void SetNpcBehaviorIsLaugh(bool value)
    {
        // Find all game objects with the tag "npc"
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");

        // Loop through each NPC and set isLaugh to the specified value
        foreach (GameObject npc in npcs)
        {
            npcBehavior npcScript = npc.GetComponent<npcBehavior>();
            if (npcScript != null)
            {
                npcScript.isLaugh = value;
            }
        }
    }
}
