using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollow : MonoBehaviour
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

    public float speed = 1.0f;

    // Start is called before the first frame update

    public LineRenderer lineOfSight;

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
            //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            //transform.LookAt(PlayerController.instance.transform.position);
            Vector3 targetDirection = PlayerController.instance.transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
            

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, newDirection, maxDistance);


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

            if (onTime <= 0)
            {
                isOn = false;
                offTime = offCount;
                lineOfSight.gameObject.SetActive(false);
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
            }
        }
    }
}
