using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buzSaw : MonoBehaviour
{
    public AudioSource sawSound;
    // Configurable properties
    public float rotationSpeed = 50f;  // Degrees per second
    public float translationSpeed = 2f;  // Units per second
    public float translationDistance = 10f;  // Units to move

    private float originalX;
    private bool movingForward = true;

    void Start()
    {
        originalX = transform.position.x;  // Use transform directly
    }

    void Update()
    {
        // Rotate the object itself around Z-axis
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        // Translate the object itself along X-axis
        if (movingForward)
        {
            transform.Translate(Vector3.right * translationSpeed * Time.deltaTime, Space.World);
            if (transform.position.x >= originalX + translationDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.Translate(-Vector3.right * translationSpeed * Time.deltaTime, Space.World);
            if (transform.position.x <= originalX)
            {
                movingForward = true;
            }
        }
        

    }
    private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("Player")){
                Debug.Log("soundSaw");
                sawSound.Play();
            }

        }
}
