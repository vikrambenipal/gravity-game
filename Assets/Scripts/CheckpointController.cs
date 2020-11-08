using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Vector2 spawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawnPoint = PlayerController.instance.transform.position;
    }


    // Set latest checkpoint for the player 
    public void SetSpawnPoint(Vector2 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
