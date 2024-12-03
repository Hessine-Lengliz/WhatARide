using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBehavior : MonoBehaviour
{
    public string playerTag = "Player";
    public float rotationSpeed = 5f;
    public float damping = 10f; // Additional damping to smooth the rotation

    private GameObject player;

    private Animator animator;
    public bool isLaugh = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isLaugh = false;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);

        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the tag: " + playerTag);
        }

        if (player != null)
        {
            // Calculate the direction from the cube to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Create a rotation based on the direction to the player
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, rotationSpeed * Time.deltaTime);

            // Additional damping to smooth the rotation (adjust as needed)
            float angle = Quaternion.Angle(transform.rotation, rotationToPlayer);
            float dampingFactor = Mathf.Clamp01(damping * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, angle * dampingFactor);

            // Debug logs for testing
            Debug.DrawRay(transform.position, directionToPlayer, Color.red); // Visualize the direction to the player
            Debug.Log("Direction to player: " + directionToPlayer);
            Debug.Log("Rotation to player: " + rotationToPlayer.eulerAngles);
            
                animator.SetBool("isLaugh", isLaugh);
                
            
        }
    }
}
