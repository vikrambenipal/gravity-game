using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float airSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    // Grounded
    public bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    // Double Jump
    public float doubleJumpForce;
    public bool canDoubleJump;

    // Coyote time 
    public float hangTime = 0.2f;
    public float hangCount;

    // Gravity
    private bool isUpsideDown;
    public int gravityCount;

    // Particle Effects
    public GameObject deathParticleEffect;
    public ParticleSystem gravityParticleEffect;

    // Sprite
    public bool facingRight = true;

    // Animator
    public Animator anim;

    // Stop Input
    public bool stopInput;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        isUpsideDown = false;

        deathParticleEffect.SetActive(false);

        anim = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        // Ground Collision Detection 
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .3f, whatIsGround);

        if (isGrounded)
        {
            //canDoubleJump = true;
            gravityCount = 2;
        }


        // Coyote time set-up
        HangTime();
        

        // Jump on input while on ground 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            
        }else if(Input.GetButtonDown("Jump") && !isGrounded && canDoubleJump)
        {
            //theRB.velocity = new Vector2(theRB.velocity.x, doubleJumpForce);
            //canDoubleJump = false;
        }

        // Invert Gravity
        if (Input.GetKeyDown(KeyCode.Z) && (isGrounded || gravityCount > 0))
        {
            gravityParticleEffect.gravityModifier *= -1;
            Instantiate(gravityParticleEffect, transform.position, Quaternion.identity);
            theRB.gravityScale *= -1;
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            isUpsideDown = !isUpsideDown;
            --gravityCount;
        }


            // Coyote Time 
            if (hangCount > 0 && Input.GetButtonDown("Jump") && !isGrounded)
        {
            Jump();
        }


        // Walk
        Walk();

        // Flip Direction / Sprite Method 
        if(Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            Flip();
            facingRight = true;
        }
        else if(Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            Flip();
            facingRight = false;
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetInteger("gravityCount", gravityCount);

    }

    // METHODS:

    // Walking
    void Walk()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
    }

    // Jump Method 
    void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
    }

    // When player changes horizontal direction 
    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Jumping Hangtime 
    void HangTime()
    {
        if (isGrounded)
        {
            hangCount = hangTime;
        }
        else
        {
            hangCount -= Time.deltaTime;
        }
    }

    public void ResetPlayer()
    {
        gravityParticleEffect.gravityModifier = 1;
        theRB.gravityScale = 3;
        isUpsideDown = false;
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z); 
    }

    // player interaction with moving platforms 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Debug.Log("1");
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Debug.Log("2");
            transform.parent = null;
        }
    }
}
