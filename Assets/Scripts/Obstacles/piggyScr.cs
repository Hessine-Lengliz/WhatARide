using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piggyScr : MonoBehaviour
{
    public bool isLeft = false;
    public AudioSource pigChase, pigHit;
    public GameObject objectPrefab; // Drag your prefab to this field in the Inspector
    public float followSpeed = 5f; // Speed at which the spawned object follows the player
    public float spawnDistance = 5f; // Distance from the player to spawn the object

    private GameObject pigSpawnPoint;

    void Update()
    {
        if (isLeft)
        {
            pigChase.Play();
            // Find the player object in the scene with the tag "Player"
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {

                // Calculate the position behind the player
                Vector3 spawnPosition = player.transform.position - player.transform.forward * spawnDistance;

                // Instantiate the objectPrefab at the calculated position
                pigSpawnPoint = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

                // Set isLeft back to false to avoid continuous instantiation
                isLeft = false;

                // Face the same direction as the player
                FacePlayerDirection(player.transform.forward);
            }
            else
            {
                Debug.LogError("Player object not found. Make sure it has the 'Player' tag.");
            }
        }
        

        // Follow the player with the spawned object if it exists
        if (pigSpawnPoint != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Calculate the new position behind the player
                Vector3 targetPosition = player.transform.position - player.transform.forward;

                // Move the spawned object towards the player
                pigSpawnPoint.transform.position = Vector3.MoveTowards(pigSpawnPoint.transform.position, targetPosition, followSpeed * Time.deltaTime);

                // Face the same direction as the player
                FacePlayerDirection(player.transform.forward);

                // Check for collision with player
                float distanceToPlayer = Vector3.Distance(pigSpawnPoint.transform.position, player.transform.position);
                if (distanceToPlayer < 1.0f) // You can adjust this threshold as needed
                {
                    // Collision occurred, set isLeft to false
                    isLeft = false;
                }
            }
        }
    }

    void FacePlayerDirection(Vector3 playerDirection)
    {
        // Rotate the pig to face the same direction as the player
        pigSpawnPoint.transform.rotation = Quaternion.LookRotation(playerDirection);
    }
    private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("Player")){
                pigChase.Stop();
                pigChase.Play();
            }
        }
}
