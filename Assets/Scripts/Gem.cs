using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            gameObject.SetActive(false);
            Instantiate(particle, transform.position, Quaternion.identity);
            LevelManager.instance.gemCount++;
        }
    }
}
