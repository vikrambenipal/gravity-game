using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour
{
    public float rotationSpeed;
    public float maxDistance;

    // Timer
    public bool isOn;
    public float offCount;
    private float offTime;

    public float onCount;
    private float onTime;

    public float initialTimer;

    // Start is called before the first frame update

    public LineRenderer lineOfSight;
    public GameObject particle;

    void Start()
    {
        isOn = true;
        onTime = initialTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, maxDistance);


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
            onTime -= Time.deltaTime;

            if (onTime <= 0)
            {
                isOn = false;
                offTime = offCount;
                lineOfSight.gameObject.SetActive(false);
                particle.gameObject.SetActive(false);
            }
        }
        else
        {
            offTime -= Time.deltaTime;
            if (offTime <= 0)
            {
                isOn = true;
                onTime = onCount;
                lineOfSight.gameObject.SetActive(true);
                particle.gameObject.SetActive(true);
            }
        }
    }
}
