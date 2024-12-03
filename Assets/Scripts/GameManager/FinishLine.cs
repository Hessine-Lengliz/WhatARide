using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("yayy");
           SceneManager.LoadScene(3);
        }
    }
}
