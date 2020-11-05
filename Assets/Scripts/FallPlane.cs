using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlane : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController.instance.KillPlayer();
            //FindObjectOfType<HealthController>().KillPlayer();
        }
    }
}
