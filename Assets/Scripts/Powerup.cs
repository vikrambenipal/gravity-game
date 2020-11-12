using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupManager parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Works");
            PlayerController.instance.gravityCount = 2;
            parent.RespawnPowerUp();
        }
    }

}
