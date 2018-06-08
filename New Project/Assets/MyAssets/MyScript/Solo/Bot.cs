using UnityEngine;

public class Bot : MonoBehaviour
{
    public Rigidbody rb;
    public float tmp;
    public float moveSpeed;
    private float factor;

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

    void Start ()
    {
        rb.velocity = new Vector3(0, 0, 0);
        moveSpeed = 25;
        factor = Mathf.Sqrt(2) / 2;

        tpsStart = Time.time;
        isStopped = true;
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
            rb.GetComponent<WallCreaterBot>().frequency += 1;
            fastBonus = false;
        }

        if (slowBonus && Time.time - tpsBonus2 >= 7.0f)
        {
            moveSpeed *= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x * 1.5f, rb.velocity.y, rb.velocity.z * 1.5f);
            rb.GetComponent<WallCreaterBot>().frequency -= 1;
            rb.GetComponent<WallCreaterBot>().distance = 6;
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

        if (Time.time - tmp > 1 && !GetComponent<BotDeath>().isOver)
        {
            float rdmdir = Random.Range(0.0f, 6.0f);
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
            rb.GetComponent<WallCreater>().frequency -= 1;
            tpsBonus1 = Time.time;
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.name == "Bonus2 Solo(Clone)" && !slowBonus)
        {
            moveSpeed /= 1.5f;
            rb.velocity = new Vector3(rb.velocity.x / 1.5f, rb.velocity.y, rb.velocity.z / 1.5f);
            rb.GetComponent<WallCreater>().distance = 10;
            rb.GetComponent<WallCreater>().frequency += 1;
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
