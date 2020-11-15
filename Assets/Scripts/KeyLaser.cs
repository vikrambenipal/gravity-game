using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLaser : MonoBehaviour
{
    public float rotationSpeed;
    public float maxDistance;
    public GameObject particle;

    public bool isActive;

    public static KeyLaser instance;
    // Start is called before the first frame update

    public LineRenderer lineOfSight;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, maxDistance);


        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            // particle system
            particle.transform.position = hitInfo.point;
            if (hitInfo.collider.CompareTag("Player") && isActive)
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

    public void TurnOffLaser()
    {
        lineOfSight.gameObject.SetActive(false);
        particle.gameObject.SetActive(false);
        isActive = false;
    }
}
