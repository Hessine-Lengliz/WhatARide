using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingingAxe : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float rotationRange = 45f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the desired rotation angle using Mathf.PingPong
        float targetRotation = Mathf.PingPong(Time.time * rotationSpeed, rotationRange * 2f) - rotationRange;

        // Apply the rotation to the GameObject, considering the parent's rotation
        transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 0, targetRotation);
    }
}
