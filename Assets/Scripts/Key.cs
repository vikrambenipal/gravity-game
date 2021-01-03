using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public KeyDoor door;
    public bool isCollected;
    public KeyDoor door;
    public GameObject particle;

    private void Start()
    {
        //door = GetComponentInParent<KeyDoor>();
        isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            isCollected = true;
            door.KeyUpdate();
            this.gameObject.SetActive(false);
            LevelManager.instance.currentDoor = door;
        }
    }
}
