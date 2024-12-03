using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    public AudioSource playerDeathSound;
    public ParticleSystem bloodParticleSystem;
    public GameManager gameManager;

    private void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        bloodParticleSystem = GameObject.Find("FX_BloodSplat_Small_01").GetComponent<ParticleSystem>();

    // If the particle system is not found, log a warning message
    if (bloodParticleSystem == null)
    {
        Debug.LogWarning("Particle system 'FX_BloodSplat_Small_01' not found in the scene.");
    }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Inform GameManager about the collision
            playerDeathSound.Play();
            gameManager.PlayerHitObstacle();
               bloodParticleSystem.transform.position = transform.position; // Use 'this' or 'transform' for the player's position
            bloodParticleSystem.Play();
        }
    }
    
}


    


    