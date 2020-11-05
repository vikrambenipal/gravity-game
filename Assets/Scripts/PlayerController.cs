﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ground Collision Detection 
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .3f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }


        // Coyote time set-up
        HangTime();
        

        // Jump on input while on ground 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            
        }else if(Input.GetButtonDown("Jump") && !isGrounded && canDoubleJump)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, doubleJumpForce);
            canDoubleJump = false;
        }


        // Coyote Time 
        if (hangCount > 0 && Input.GetButtonDown("Jump") && !isGrounded)
        {
            Jump();
        }


        // Walk
        Walk();

        // Flip Direction / Sprite Method 
        if(Input.GetAxis("Horizontal") > 0)
        {
            Flip();
        }
        

        // METHODS:


        // Jump Method 
        void Jump()
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);  
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

        // When player changes horizontal direction 
        void Flip()
        {
            
        }

        // Walking
        void Walk()
        {
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        }

    }
}
