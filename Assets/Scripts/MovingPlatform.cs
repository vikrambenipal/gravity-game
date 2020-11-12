using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform platform;
    public float moveSpeed;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        pos1.position = platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            platform.position = Vector3.MoveTowards(platform.position, pos2.position, moveSpeed * Time.deltaTime);
            if(platform.position == pos2.position)
            {
                isRight = false;
            }
            
        }
        else
        {
            platform.position = Vector3.MoveTowards(platform.position, pos1.position, moveSpeed * Time.deltaTime);
            if (platform.position == pos1.position)
            {
                isRight = true;
            }
            
        }
        
    }
}
