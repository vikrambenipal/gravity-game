using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyDoor door;

    private void Start()
    {
        door = GetComponentInParent<KeyDoor>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            door.KeyUpdate();
            Debug.Log("Got key");
        }
    }
}
