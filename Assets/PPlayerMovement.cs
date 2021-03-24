using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPlayerMovement : MonoBehaviour
{
    public bool isPlayerOne;
    public float speed = 5;
    public Rigidbody2D rb;
    public bool canMove = true;
    public bool isActivePlayer;
    public float strength = 4f;

    public HockeyStick stick;
    public GameObject puck;

    Vector2 movement;

    void FixedUpdate()
    {
        if (canMove)
        {
            if (isPlayerOne)
            {
                if (isActivePlayer)
                {
                    stick.gameObject.SetActive(true);
                }

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
                if (!isActivePlayer)
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        movement.y = -1;
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    movement.x = 1;
                }
                rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                if (isActivePlayer)
                {
                    Debug.Log("Please work");
                    stick.gameObject.SetActive(false);
                    float y = Random.Range(-2, 3);
                    this.transform.position.Set(this.transform.position.x, y, 0);
                    Invoke("Shoot", 1f);
                }
                else
                {

                }
            }
        }
    }

    public void Shoot()
    {
        puck.GetComponent<Rigidbody2D>().AddForce(transform.forward * strength);
    }
}

