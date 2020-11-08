﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public static HealthController instance;

    private void Awake()
    {
        instance = this;
    }

    public void KillPlayer()
    {
        LevelManager.instance.RespawnPlayer();
    }
}
