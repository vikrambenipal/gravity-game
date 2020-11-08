using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance;

    private void Awake()
    {
        instance = this;
    }

    // If player enters collision zone activate checkpoint 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

}
