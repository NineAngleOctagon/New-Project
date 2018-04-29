﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public Rigidbody rb;

    private float tps = 0;
    public float gap;
    public float moveSpeed;
    public float jumpForce;
    public Camera PlayerCam;
    private Vector3 north;
    private Vector3 south;
    private Vector3 west;
    private Vector3 east;
    private Vector3 north_East;
    private Vector3 north_West;
    private Vector3 south_East;
    private Vector3 south_West;
    Vector3 from1to2 = new Vector3(-300, 1, -150);
    Vector3 from2to1 = new Vector3(0, 1, 50);
    Vector3 from3to1 = new Vector3(0, 1, -50);
    Vector3 from3to2 = new Vector3(-300, 1, -250);
    Vector3 from1to3 = new Vector3(237.5f, 1, -250);
    Vector3 from2to3 = new Vector3(162.5f, 1, -250);

    void Start()
    {
        float factor = Mathf.Sqrt(2) / 2;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        north = new Vector3(0, rb.velocity.y, moveSpeed);
        south = new Vector3(0, rb.velocity.y, -moveSpeed);
        west = new Vector3(-moveSpeed, rb.velocity.y, 0);
        east = new Vector3(moveSpeed, rb.velocity.y, 0);
        north_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        north_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        south_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        south_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            PlayerCam.enabled = false;
            return;
        }
        float factor = Mathf.Sqrt(2) / 2;

        if (!rb.GetComponent<GameOver>().isOver)
        {
            if (Input.GetKey("d") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, 90, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north_East;
                }
                tps = Time.time;
            }

            if (Input.GetKey("q") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, -90, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = north_East;
                }
                tps = Time.time;
            }

            if (Input.GetKey("e") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, 45, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = north_East;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north;
                }
                tps = Time.time;
            }

            if (Input.GetKey("a") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, -45, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north_East;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north;
                }
                tps = Time.time;
            }

            if (Input.GetKey(KeyCode.Space) && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                rb.AddForce(0, jumpForce, 0);
            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "transporter 1 to 2")

        {
            rb.GetComponent<PlayerController>().transform.position = from1to2;
            rb.transform.Rotate(0, 180, 0);
            rb.velocity = south;
        }
        if (collision.gameObject.name == "transporter 1 to 3")

        {
            rb.GetComponent<PlayerController>().transform.position = from1to3;

            rb.velocity = south;
        }
        if (collision.gameObject.name == "transporter 2 to 1")

        {
            rb.GetComponent<PlayerController>().transform.position = from2to1;
            rb.transform.Rotate(0, 180, 0);
            rb.velocity = south;
        }
        if (collision.gameObject.name == "transporter 2 to 3")

        {
            rb.GetComponent<PlayerController>().transform.position = from2to3;

            rb.velocity = south;
        }
        if (collision.gameObject.name == "transporter 3 to 1")

        {
            rb.GetComponent<PlayerController>().transform.position = from3to1;

            rb.velocity = north;
        }
        if (collision.gameObject.name == "transporter 3 to 2")

        {
            rb.GetComponent<PlayerController>().transform.position = from3to2;

            rb.velocity = north;
        }
    }


    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        GetComponent<TrailRenderer>().material.color = Color.blue;
    }
}
