using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public static KeyDoor instance;
    public int totalKeys;
    public int keyCount;
    public Key[] keyList;

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
            KeyLaser.instance.TurnOffLaser();
        }
    }
}
