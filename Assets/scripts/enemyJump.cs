using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyJump : MonoBehaviour
{

    public float jumpTimer = 3f;
    public float jumpForce = 6f;
    public float forceTimer = 0.85f;

    public Rigidbody2D rb2D;


    // Update is called once per frame
    void Update()
    {
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
