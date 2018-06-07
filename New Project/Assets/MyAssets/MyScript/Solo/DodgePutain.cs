using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePutain : MonoBehaviour {

    public GameObject left;
    public bool bool_Left;
    public GameObject right;
    public bool bool_Right;
    public GameObject front;
    public bool bool_Front;
    public GameObject front_Left;
    public bool bool_Front_Left;
    public GameObject front_Right;
    public bool bool_Front_Right;
    private float tps;

    public float jumpForce;
    public float moveSpeed;
    private float factor = Mathf.Sqrt(2) / 2;
    public Rigidbody rb;

    private void Start()
    {
        tps = Time.time;
    }

    // Update is called once per frame
    void Update () {
        bool_Left = left.GetComponent<Idetectedsmth>().detected;
        bool_Right = right.GetComponent<Idetectedsmth>().detected;
        bool_Front = front.GetComponent<Idetectedsmth>().detected;
        bool_Front_Left = front_Left.GetComponent<Idetectedsmth>().detected;
        bool_Front_Right = front_Right.GetComponent<Idetectedsmth>().detected;

        if (this.transform.position.y < 0.51 && this.transform.position.y > 0.49)
        {
            rb.GetComponent<MoveBot>().enabled = true;
            if (bool_Front_Left && bool_Left && !bool_Right)
            {
                Turn_Left();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }

            if (bool_Front_Right && bool_Right && !bool_Left)
            {
                Turn_Right();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }
            if (!bool_Left && !bool_Right && !bool_Front_Right && bool_Front_Left)
            {
                Turn_Front_Left();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }

            if (!bool_Left && !bool_Right && !bool_Front_Left && bool_Front_Right)
            {
                Turn_Front_Right();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }

            if(bool_Front_Left && bool_Front && bool_Front_Right && !bool_Left && !bool_Right)
            {
                Turn_Right();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }

            if (bool_Front_Left && bool_Front_Right && !bool_Front && !bool_Left && !bool_Right)
            {
                Turn_Left();
                tps = Time.time;
                rb.GetComponent<MoveBot>().enabled = false;
            }

            left.GetComponent<Idetectedsmth>().detected = false;
            right.GetComponent<Idetectedsmth>().detected = false;
            front.GetComponent<Idetectedsmth>().detected = false;
            front_Left.GetComponent<Idetectedsmth>().detected = false;
            front_Right.GetComponent<Idetectedsmth>().detected = false;
        }
    }

    public void Turn_Left()
    {
        transform.Rotate(new Vector3(0, 90, 0));
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
}
