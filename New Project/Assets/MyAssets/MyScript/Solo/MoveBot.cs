using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour {

    public Rigidbody rb;
    public float jumpForce;
    public float moveSpeed;
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

    private float tpsmovebot;
    public float tpsStart;
    public bool isStopped;

    private void Start()
    {
        rb.velocity = new Vector3(0, 0, 0);
        tpsmovebot = Time.time;

        tpsStart = Time.time;
        isStopped = true;
    }

    private void FixedUpdate()
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
            rb.GetComponent<WallCreater>().frequency += 1;
            fastBonus = false;
        }

        if (slowBonus && Time.time - tpsBonus2 >= 7.0f)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            rb.GetComponent<WallCreater>().frequency -= 1;
            rb.GetComponent<WallCreater>().distance = 6;
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
        
        if (rb.transform.position.y > 0.49 && rb.transform.position.y < 0.51 && Time.time - tpsmovebot >= 2f)
        {
            int move = (int)Random.Range(0f, 4.0f);
            switch (move)
            {
                case 0:
                    Turn_Left();
                    break;
                case 1:
                    Turn_Right();
                    break;
                case 2:
                    Turn_Front_Left();
                    break;
                case 3:
                    Turn_Front_Right();
                    break;
                default:
                    break;
            }
            tpsmovebot = Time.time;
        }

        rb.freezeRotation = true;
    }

    public void Turn_Left()
    {
        transform.Rotate(new Vector3(0,90,0));
        if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
        }
        else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
    }

    public void Turn_Right()
    {
        transform.Rotate(new Vector3(0, -90, 0));
        if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
        }
        else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
    }

    public void Turn_Front_Left()
    {
        transform.Rotate(new Vector3(0, 45, 0));
        if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
        }
        else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        }
    }

    public void Turn_Front_Right()
    {
        transform.Rotate(new Vector3(0, -45, 0));
        if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
        }
        else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }
        else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
        {
            rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        }
    }

    public void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
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

        if (collision.collider.name == "Bonus1(Clone)" && !fastBonus)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            fastBonus = true;
            rb.GetComponent<WallCreater>().frequency -= 1;
            tpsBonus1 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus2(Clone)" && !slowBonus)
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreater>().distance = 10;
            rb.GetComponent<WallCreater>().frequency += 1;
            slowBonus = true;
            tpsBonus2 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus3(Clone)" && !ghostBonus)
        {
            ghostBonus = true;
            tpsBonus3 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus4(Clone)" && !bigWall)
        {
            bigWall = true;
            tpsBonus4 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
    }
}
