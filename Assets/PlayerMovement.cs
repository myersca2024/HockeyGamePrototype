using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isPlayerOne;
    public float speed = 5;
    public Rigidbody2D rb;

    Vector2 movement;

    void FixedUpdate()
    {
        if (isPlayerOne)
        {
            movement.x = 0;
            movement.y = 0;
            if (Input.GetKey(KeyCode.W))
            {
                movement.y = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement.y = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1;
            }
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
            if (Input.GetKey(KeyCode.I))
            {
                movement.y = 1;
            }
            if (Input.GetKey(KeyCode.J))
            {
                movement.x = -1;
            }
            if (Input.GetKey(KeyCode.K))
            {
                movement.y = -1;
            }
            if (Input.GetKey(KeyCode.L))
            {
                movement.x = 1;
            }
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}
