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
    public float strength = 15f;

    public bool haveMoved;

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
                    if (!haveMoved)
                    {
                        haveMoved = true;
                        stick.gameObject.SetActive(false);
                        float y = Random.Range(-2, 3);
                        rb.MovePosition(new Vector3((transform.position.x + y), transform.position.y, 0));
                        puck.GetComponent<Rigidbody2D>().MovePosition(new Vector3((puck.transform.position.x + y), puck.transform.position.y, 0));
                        Invoke("Shoot", 1f);
                    }
                }
                else
                {

                }
            }
        }
    }

    public void Shoot()
    {
        puck.GetComponent<Rigidbody2D>().AddForce(transform.up * strength);
    }
}

