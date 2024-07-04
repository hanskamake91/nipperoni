using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    // Creating variables for move speed and jump force, ground checking to enable jumping, hangtime and jumpbuffer to manage jumping,
    // move enabling to manage movement with taking damage
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Rigidbody2D rb2D;

    public Transform groundCheckPoint; //groundCheckPoint2;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public float hangTime = 0.2f;
    private float hangCounter;

    public float jumpBufferLength = 0.1f;
    private float jumpBufferCount;

    public bool moveEnabled;


    // Update is called once per frame
    void Update()
    {
        // Move in X if moveEnabled = true
        if (moveEnabled)
        {
            rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        }

        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.1f, whatIsGround); //|| Physics2D.OverlapCircle(groundCheckPoint2.position, 0.1f, whatIsGround);

        // Manage hangtime
        if (isGrounded)
        {
            hangCounter = hangTime;
        } else
        {
            hangCounter -= Time.deltaTime;
        }

        // Manage jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLength;
        } else 
        {
            jumpBufferCount -= Time.deltaTime;
        }

        // Player jump
        if (jumpBufferCount >= 0 && hangCounter > 0f)
        {
            rb2D.velocity =  new Vector2(rb2D.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }
}
