using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bot : NetworkBehaviour {

    public Rigidbody rb;
    private float tmp;
    public float moveSpeed;
    private float factor;

    private Vector3 from1to2 = new Vector3(-300, 0.5f, -140);
    private Vector3 from2to1 = new Vector3(0, 0.5f, 60);
    private Vector3 from3to1 = new Vector3(0, 0.5f, -60);
    private Vector3 from3to2 = new Vector3(-301, 0.5f, -260);
    private Vector3 from1to3 = new Vector3(237.5f, 0.5f, -240);
    private Vector3 from2to3 = new Vector3(162.5f, 0.5f, -240);

    public float tpsBonus;
    private bool fastBonus = false;
    private bool slowBonus = false;
    public bool ghostBonus = false;
    public bool bigWall = false;
    public bool bigWallCreate = false;

    // Use this for initialization
    void Start () {
        rb.velocity = new Vector3(25, rb.velocity.y, 0);
        moveSpeed = 25;
        factor = Mathf.Sqrt(2) / 2;
	}

    // Update is called once per frame
    void FixedUpdate()
    {


        if (fastBonus && Time.time - tpsBonus >= 7.0f)
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreater>().frequency += 1;
            fastBonus = false;
        }

        if (slowBonus && Time.time - tpsBonus >= 7.0f)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            rb.GetComponent<WallCreater>().frequency -= 1;
            rb.GetComponent<WallCreater>().distance = 6;
            slowBonus = false;
        }

        if (ghostBonus && Time.time - tpsBonus >= 7.0f)
        {
            ghostBonus = false;
        }

        if (bigWall && Time.time - tpsBonus >= 7.0f)
        {
            bigWall = false;
        }

        if (Time.time - tmp > 0.3f && !GetComponent<BotDeath>().isOver)
        {
            float rdmdir = Random.Range(0.0f, 4.0f);
            switch ((int)rdmdir)
            {
                case 0:
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
                    break;
                case 1:
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
                    break;
                case 2:
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
                    break;
                default:
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
                    break;
            }
            tmp = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "transporter 1 to 2")
        {
            rb.transform.position = new Vector3(0, 200.5f, 80);
            rb.velocity = new Vector3(-300, 0, -220);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 1 to 2")
        {
            rb.transform.position = new Vector3(-300, 0.5f, -140);
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            rb.transform.Rotate(0, 180, 0);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter 1 to 3")
        {
            rb.transform.position = new Vector3(0, 200.5f, -80);
            rb.velocity = new Vector3(236.3f, 0, -160.545f);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 1 to 3")
        {
            rb.transform.position = from1to3;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter 2 to 1")
        {
            rb.transform.position = new Vector3(-300, 200.5f, -120);
            rb.velocity = new Vector3(297.4f, 0, 184.3f);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 2 to 1")
        {
            rb.transform.position = from2to1;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            rb.transform.Rotate(0, 180, 0);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter 2 to 3")
        {
            rb.transform.position = new Vector3(-300, 200.5f, -280);
            rb.velocity = new Vector3(462.5f, 0, 40);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 2 to 3")
        {
            rb.transform.position = from2to3;
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter 3 to 1")
        {
            rb.transform.position = new Vector3(237.5f, 200.5f, -220);
            rb.velocity = new Vector3(-237.5f, 0, 160);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 3 to 1")
        {
            rb.transform.position = from3to1;
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter 3 to 2")
        {
            rb.transform.position = new Vector3(162.5f, 200.5f, -220);
            rb.velocity = new Vector3(-462.5f, 0, -40);
            tpsBonus = 0;
        }
        if (collision.gameObject.name == "transporter chemin 3 to 2")
        {
            rb.transform.position = from3to2;
            rb.velocity = new Vector3(0, rb.velocity.y, 25);
            tpsBonus = 0;
        }

        if (collision.collider.name == "Bonus1(Clone)")
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            fastBonus = true;
            rb.GetComponent<WallCreater>().frequency -= 1;
            tpsBonus = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus2(Clone)")
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreater>().distance = 10;
            rb.GetComponent<WallCreater>().frequency += 1;
            slowBonus = true;
            tpsBonus = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus3(Clone)")
        {
            ghostBonus = true;
            tpsBonus = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus4(Clone)")
        {
            bigWall = true;
            bigWallCreate = true;
            tpsBonus = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
    }
}
