using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSpikeGrate : MonoBehaviour
{
    public string childObjectName = "Spikes";
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Transform spikesTransform;
    private Vector3 initialPosition;
    private float targetPosition;

    public bool spikeTrigger = false;

    void Start()
    {
        // Find the child GameObject by name
        Transform childTransform = transform.Find(childObjectName);

        // Check if the child exists
        if (childTransform != null)
        {
            spikesTransform = childTransform;
            initialPosition = spikesTransform.position;
            targetPosition = initialPosition.y + moveDistance;
        }
        else
        {
            Debug.LogError("Child object with name '" + childObjectName + "' not found!");
        }
    }

    void Update()
    {
        if (spikesTransform != null)
        {
            if (spikeTrigger)
            {
                // Move the child object towards the target position
                float step = moveSpeed * Time.deltaTime;
                spikesTransform.position = Vector3.MoveTowards(spikesTransform.position, new Vector3(initialPosition.x, targetPosition, initialPosition.z), step);
            }
            if (!spikeTrigger)
            {
                // Debug.Log("player not collided yet");
            }
        }
       
    }
}
