using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowFall : MonoBehaviour
{
    public GameObject cowPrefab;
    public AudioSource cowMoo;
    public GameObject player;
      public float fallForce = 2;
    private void Start() {
        
         CowFallActive(player);
    }
    
    
     private void CowFallActive(GameObject player)
    {
        cowMoo.Play();
        // Instantiate the cow prefab above the player
       Vector3 cowSpawnPosition = player.transform.position + Vector3.up * 20f; // Adjust the height as needed
        GameObject cow = Instantiate(cowPrefab, cowSpawnPosition, Quaternion.identity);

        // Apply a force to make the cow fall
        Rigidbody cowRigidbody = cow.GetComponent<Rigidbody>();
        if (cowRigidbody != null) {
            cowRigidbody.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
        }

        // Call a method in GameManager to handle player hit
        
    }
}
