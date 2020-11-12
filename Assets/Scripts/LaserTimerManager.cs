using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimerManager : MonoBehaviour
{
    public float rotationSpeed;
    public float maxDistance;

    // Timer
    public bool isOn;
    public float offCount;
    private float offTime;

    public float onCount;
    private float onTime;

    // Start is called before the first frame update

    public LineRenderer lineOfSight;

    void Start()
    {
        isOn = true;
        onTime = onCount;
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

            if(onTime <= 0)
            {
                isOn = false;
                offTime = offCount;
            }
        }
        else
        {
            offTime -= Time.deltaTime;
            if(offTime <= 0)
            {
                isOn = true;
                onTime = onCount;
            }
        }
    }
}
