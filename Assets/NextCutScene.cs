using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCutScene : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Player")){
        Debug.Log("hi");
        SceneManager.LoadScene(2);
    }
   }
}
