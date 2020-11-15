using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float rotationSpeed;
    public float maxDistance;
    public GameObject particle;
    int layer_mask;
    //public LayerMask Item;

    // Start is called before the first frame update

    public LineRenderer lineOfSight;
    


    void Start()
    {
        layer_mask = LayerMask.GetMask("Player", "Ground");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, maxDistance, layer_mask);

        



        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);

            // particle system
            particle.transform.position = hitInfo.point;

            if (hitInfo.collider.CompareTag("Player"))
            {
                HealthController.instance.KillPlayer();
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up * maxDistance, Color.green);
            lineOfSight.SetPosition(1, transform.position + (transform.up * maxDistance));
        }

        lineOfSight.SetPosition(0, transform.position);

    }
}
