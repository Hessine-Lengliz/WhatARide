using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapVisibelety : MonoBehaviour
{
    public GameObject targetGameObject;  // The GameObject to change visibility

    void Start()
    {
        targetGameObject.SetActive(false);  // Set initially invisible
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetGameObject.SetActive(true);  // Set visible on player trigger
        }
    }
}
