using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyJump : MonoBehaviour
{

    // Creating variables for interval of jumps, force of jump and how long that force is applied
    public float jumpTimer = 3f;
    public float jumpForce = 6f;
    public float forceTimer = 0.85f;

    public Rigidbody2D rb2D;


    // Update is called once per frame
    void Update()
    {
        // Timer starts running, when it reaches zero enemy jumps and then timer for how long force is applied to enemy object starts
        // and when it reaches zero, enemy object will land with force of gravity
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0.0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            forceTimer -= Time.deltaTime;

            if (forceTimer <= 0.0f)
            {
                forceTimer = 0.85f;
                jumpTimer = 3f;
                rb2D.velocity = new Vector2(0.0f, 0.0f);
            }
        }
    }
}
