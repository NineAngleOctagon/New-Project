﻿using UnityEngine;

public class PlayerControllerSolo : MonoBehaviour
{
    public Rigidbody rb;

    private float tps = 0;
    public float gap;
    public float moveSpeed;
    public float jumpForce;
    public Camera PlayerCam;
    private float factor = Mathf.Sqrt(2) / 2;

    private Vector3 from2to1 = new Vector3(0, 0.5f, 60);
    private Vector3 from3to1 = new Vector3(0, 0.5f, -60);
    private Vector3 from3to2 = new Vector3(-301, 0.5f, -260);
    private Vector3 from1to3 = new Vector3(237.5f, 0.5f, -240);
    private Vector3 from2to3 = new Vector3(162.5f, 0.5f, -240);

    public float tpsBonus1;
    public float tpsBonus2;
    public float tpsBonus3;
    public float tpsBonus4;
    private bool fastBonus = false;
    private bool slowBonus = false;
    public bool ghostBonus = false;
    public bool bigWall = false;

    public float tpsStart;
    public bool isStopped;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);

        tpsStart = Time.time;
        isStopped = true;

        GetComponent<MeshRenderer>().material.color = new Color(0, 0, 255, 255);
        GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        GetComponent<TrailRenderer>().material.color = new Color(0, 0, 255, 255);
        GetComponent<TrailRenderer>().material.DisableKeyword("_EMISSION");
    }

    void FixedUpdate()
    {
        if (isStopped)
        {
            if (!(Time.time - tpsStart <= 5.0f))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
                isStopped = false;
            }
        }

        if (fastBonus && Time.time - tpsBonus1 >= 7.0f)
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreaterSolo>().frequency += 1;
            fastBonus = false;
        }

        if (slowBonus && Time.time - tpsBonus2 >= 7.0f)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            rb.GetComponent<WallCreaterSolo>().frequency -= 1;
            rb.GetComponent<WallCreaterSolo>().distance = 6;
            slowBonus = false;
        }

        if (ghostBonus && Time.time - tpsBonus3 >= 7.0f)
        {
            ghostBonus = false;
        }

        if (bigWall && Time.time - tpsBonus4 >= 7.0f)
        {
            bigWall = false;
        }

        if (!rb.GetComponent<GameOverSolo>().isOver)
        {
            if (Input.GetKey("d") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
                {
                    rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
                {
                    rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, 90, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("q") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
                {
                    rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
                {
                    rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, -90, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("e") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
                    transform.Rotate(0, 45, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("a") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
                {
                    rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
                {
                    rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
                    transform.Rotate(0, -45, 0);
                }
                tps = Time.time;
            }

            if (Input.GetKey("l"))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }

            if (Input.GetKey(KeyCode.Space) && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                rb.AddForce(0, jumpForce, 0);
            }


        }

    }
    private void Update()
    {
        rb.angularVelocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "transporter 1 to 2")
        {
            rb.transform.position = new Vector3(0, 200.5f, 80);
            rb.velocity = new Vector3(-300, 0, -220);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 1 to 2")
        {
            rb.transform.position = new Vector3(-300, 0.5f, -140);
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            rb.transform.Rotate(0, 180, 0);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter 1 to 3")
        {
            rb.transform.position = new Vector3(0, 200.5f, -80);
            rb.velocity = new Vector3(236.3f, 0, -160.545f);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 1 to 3")
        {
            rb.transform.position = from1to3;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter 2 to 1")
        {
            rb.transform.position = new Vector3(-300, 200.5f, -120);
            rb.velocity = new Vector3(297.4f, 0, 184.3f);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 2 to 1")
        {
            rb.transform.position = from2to1;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            rb.transform.Rotate(0, 180, 0);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter 2 to 3")
        {
            rb.transform.position = new Vector3(-300, 200.5f, -280);
            rb.velocity = new Vector3(462.5f, 0, 40);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 2 to 3")
        {
            rb.transform.position = from2to3;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter 3 to 1")
        {
            rb.transform.position = new Vector3(237.5f, 200.5f, -220);
            rb.velocity = new Vector3(-237.5f, 0, 160);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 3 to 1")
        {
            rb.transform.position = from3to1;
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter 3 to 2")
        {
            rb.transform.position = new Vector3(162.5f, 200.5f, -220);
            rb.velocity = new Vector3(-462.5f, 0, -40);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }
        if (collision.gameObject.name == "transporter chemin 3 to 2")
        {
            rb.transform.position = from3to2;
            rb.velocity = new Vector3(0, rb.velocity.y, 25);
            tpsBonus1 = 0;
            tpsBonus2 = 0;
            tpsBonus3 = 0;
            tpsBonus4 = 0;
        }

        if (collision.collider.name == "Bonus1 Solo(Clone)" && !fastBonus)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            fastBonus = true;
            rb.GetComponent<WallCreaterSolo>().frequency -= 1;
            tpsBonus1 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus2 Solo(Clone)" && !slowBonus)
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreaterSolo>().distance = 10;
            rb.GetComponent<WallCreaterSolo>().frequency += 1;
            slowBonus = true;
            tpsBonus2 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus3 Solo(Clone)" && !ghostBonus)
        {
            ghostBonus = true;
            tpsBonus3 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus4 Solo(Clone)" && !bigWall)
        {
            bigWall = true;
            tpsBonus4 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
    }
}

