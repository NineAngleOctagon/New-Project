using UnityEngine;
using UnityEngine.Networking;

public class BotDeath : NetworkBehaviour
{

    public Rigidbody rb;
    public bool isOver;
    private Vector3 speed;
    private Quaternion rotPlayer;

    public void Start()
    {
        isOver = false;
        rb.GetComponent<Bot>().moveSpeed = 25;
        rb.isKinematic = false;
    }

    private void Update()
    {
        speed = rb.velocity;
        rotPlayer = rb.transform.rotation;

        if (rb.position.y <= -1)
        {
            isOver = true;

            rb.GetComponent<Bot>().moveSpeed = 0;
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            if (!rb.GetComponent<Bot>().ghostBonus)
            {
                isOver = true;

                rb.GetComponent<Bot>().moveSpeed = 0;
                rb.isKinematic = true;
            }
            else
            {
                Destroy(collision.gameObject);
                rb.velocity = speed;
                rb.transform.rotation = rotPlayer;
                rb.angularVelocity = Vector3.zero;
            }
        }

        if (collision.gameObject.name == "Player(Clone)" || collision.gameObject.name == "'Bot'")
        {
            isOver = true;

            rb.GetComponent<Bot>().moveSpeed = 0;
            rb.isKinematic = true;
        }

        if (collision.collider.name == "Bonus1(Clone)" || collision.collider.name == "Bonus2(Clone)" || collision.collider.name == "Bonus3(Clone)" || collision.collider.name == "Bonus4(Clone)")
        {
            collision.collider.gameObject.SetActive(false);
            rb.transform.rotation = rotPlayer;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

