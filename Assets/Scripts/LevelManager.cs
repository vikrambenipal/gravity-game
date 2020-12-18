using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator transition; 
    public static LevelManager instance;
    public float respawnTime;
    public float deathAnimationTime;
    public int gemCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.deathParticleEffect.SetActive(true);

        Instantiate(PlayerController.instance.deathParticleEffect, PlayerController.instance.transform.position, Quaternion.identity);

        // In the scenerio a player dies while on a moving platform:
        PlayerController.instance.transform.parent = null;

        // If a Player was holding a Gem
        if(PlayerController.instance.playerGemCarry != null)
        {
            PlayerController.instance.playerGemCarry.RespawnGem();
        }

        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(deathAnimationTime);
        PlayerController.instance.deathParticleEffect.SetActive(false);


        transition.SetTrigger("Start");
        yield return new WaitForSeconds(respawnTime);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        PlayerController.instance.facingRight = true;

        PlayerController.instance.ResetPlayer();
        transition.SetTrigger("End");
    }

    public void EndLevel()
    {
        //StartCoroutine(EndLevelCo());
    }

    //private IEnumerator EndLevelCo()
    //{

    //}

}
