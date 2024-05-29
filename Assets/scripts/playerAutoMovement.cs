using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAutoMovement : MonoBehaviour
{

    public float moveForce = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * moveForce);
    }
}
