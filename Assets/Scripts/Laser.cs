using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float rotationSpeed;
    public float maxDistance; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, maxDistance);
        Debug.DrawLine(transform.position, transform.position + transform.up * maxDistance, Color.green);


        if (hitInfo)
        {
            if (hitInfo.collider.tag == "Player")
            {
                Debug.Log("3");
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * maxDistance, Color.green);
        }

        

        /*
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * maxDistance, Color.green);
        }
        */
    }
}
