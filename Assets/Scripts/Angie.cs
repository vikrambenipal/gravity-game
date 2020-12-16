using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angie : MonoBehaviour
{
    public static Angie instance; 
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public bool respawn = true;
    public bool playerSpotted = false;
    private Vector2 spawnPosition;

    public float respawnTime; 

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthController.instance.KillPlayer();

            StartCoroutine(RespawnAngie());
        }
    }

    private IEnumerator RespawnAngie()
    {
        yield return new WaitForSeconds(respawnTime);
        respawn = true;
        playerSpotted = false;
    }

    private void Update()
    {
        if (respawn)
        {
            transform.position = spawnPosition;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerSpotted)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        
    }
}
