using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirlceEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthController.instance.KillPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
