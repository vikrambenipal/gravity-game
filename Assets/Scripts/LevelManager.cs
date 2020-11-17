﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Animator transition; 
    public static LevelManager instance;
    public float respawnTime;
    public float deathAnimationTime;

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
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(deathAnimationTime);
        PlayerController.instance.deathParticleEffect.SetActive(false);


        transition.SetTrigger("Start");
        yield return new WaitForSeconds(respawnTime);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.ResetPlayer();
        transition.SetTrigger("End");
    }


}
