using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public AudioSource lightningBolt;
    private GameManager gameManager;

    public ParticleSystem lightningParticleSystem;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("PlayerDetected");

            ActivateLightningStrike(other.gameObject);
            
        }
    }

    private void ActivateLightningStrike(GameObject player)
    {
        // Activate the particle system at the player's position
        lightningBolt.Play();
        lightningParticleSystem.transform.position = player.transform.position;
        lightningParticleSystem.Play();
        

        // Call a method in GameManager to handle player hit
        gameManager.PlayerHitObstacle();
    }
}
