using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public Gem gem;

    private void Start()
    {
        gem = GetComponentInChildren<Gem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && gem.isCollected)
        {
            LevelManager.instance.gemCount++;
            PlayerController.instance.playerGemCarry = null;
        }
    }
}
