using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Animator transition; 
    public static LevelManager instance;
    public float respawnTime;
    public float deathAnimationTime;
    public int gemCount;
    public float endLevelWait;
    public float bufferTimeFade;
    public GameObject levelCompletedText;
    public string nextLevel;

    public KeyDoor currentDoor = null;
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

        

        PlayerController.instance.gameObject.SetActive(false);
        PlayerController.instance.isDead = true;
        yield return new WaitForSeconds(deathAnimationTime);
        PlayerController.instance.deathParticleEffect.SetActive(false);


        transition.SetTrigger("Start");
        yield return new WaitForSeconds(respawnTime);
        

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.localScale = new Vector3(Mathf.Abs(PlayerController.instance.transform.localScale.x), PlayerController.instance.transform.localScale.y, PlayerController.instance.transform.localScale.z);
        PlayerController.instance.facingRight = true;

        PlayerController.instance.ResetPlayer();

        // If a Player was holding a Gem
        if (PlayerController.instance.playerGemCarry != null)
        {
            PlayerController.instance.playerGemCarry.RespawnGem();
        }

        if (currentDoor && !currentDoor.permaOff)
        {
            currentDoor.RespawnKeys();
            currentDoor.laser.TurnOnLaser();
        }
        

        transition.SetTrigger("End");
        
        StartCoroutine(PlayerCanMoveAgainCo());
        
    }

    private IEnumerator PlayerCanMoveAgainCo()
    {
        yield return new WaitForSeconds(0.75f);
        PlayerController.instance.isDead = false;
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    private IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        levelCompletedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(endLevelWait);
        transition.SetTrigger("Start");
        levelCompletedText.gameObject.SetActive(false);
        SceneManager.LoadScene(nextLevel);
    }

}
