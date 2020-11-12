using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Powerup child;
    public float respawnTime;

    public void RespawnPowerUp()
    {
        StartCoroutine(RespawnPowerUpCo());
    }

    private IEnumerator RespawnPowerUpCo()
    {
        child.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        child.gameObject.SetActive(true);
    }
}
