using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public float respawnTime;

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
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.ResetPlayer();
    }

}
