using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngieParent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Angie.instance.playerSpotted = true;
            Angie.instance.respawn = false;
        }
    }
}
