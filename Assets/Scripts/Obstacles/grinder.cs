using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grinder : MonoBehaviour
{
    public float rotationSpeed = 50f;  // Degrees per second
    public float moveSpeed = 5f;  // Units per second for forward movement
    public float targetDistance = 10f;  // Desired traveled distance in units

    private float totalDistanceMoved = 0f;

    void Start()
    {

    }

    void Update()
    {
        // Rotate the object itself around Z-axis
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        // Calculate the distance to move based on the fixed moveSpeed
        float distanceToMove = moveSpeed * Time.deltaTime;

        // Check if the total distance moved is less than the target distance
        if (totalDistanceMoved < targetDistance)
        {
            // Move the object forward
            transform.Translate(Vector3.left * distanceToMove, Space.World);

            // Update the total distance moved
            totalDistanceMoved += distanceToMove;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit! with grinder ");  // Send the "hit" message

            // You can add additional actions here, like:
            // - Applying damage to the player
            // - Triggering sound effects
            // - Activating visual effects
            // - Invoking other scripts
        }
    }
}
