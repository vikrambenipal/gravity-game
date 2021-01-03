using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public static KeyDoor instance;
    public int totalKeys;
    public int keyCount;
    public Key[] keyList;
    public KeyLaser laser;
    public bool permaOff = false;

    // cp is used to determine whether or not to permantently turn off the laser once a player has reached a certain point 
    public Checkpoint cp;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        keyList = GetComponentsInChildren<Key>();
        //Debug.Log(keyList.Length);
        totalKeys = keyList.Length;
    }


    public void KeyUpdate()
    {
        ++keyCount;
        if(keyCount == totalKeys)
        {
            laser.TurnOffLaser();
        }
    }

    public void RespawnKeys()
    {
        int len = keyList.Length;
        for(int i = 0; i < len; ++i)
        {
            keyList[i].isCollected = false;
            keyList[i].gameObject.SetActive(true);
            keyCount = 0;
        }
    }
}
