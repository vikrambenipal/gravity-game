using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject particle;
    public bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            gameObject.SetActive(false);
            Instantiate(particle, transform.position, Quaternion.identity);
            isCollected = true;
            PlayerController.instance.playerGemCarry = this;
        }
    }

    public void RespawnGem()
    {
        gameObject.SetActive(true);
        isCollected = false;
    }
}
