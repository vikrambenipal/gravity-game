using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public KeyDoor door;
    public bool isCollected;
    public KeyDoor door;

    private void Start()
    {
        //door = GetComponentInParent<KeyDoor>();
        isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            door.KeyUpdate();
            this.gameObject.SetActive(false);
            Debug.Log("Got key");
        }
    }
}
