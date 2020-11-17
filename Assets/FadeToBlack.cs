using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack instance;

    private void Awake()
    {
        instance = this;
    }

    public void playerDied()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
