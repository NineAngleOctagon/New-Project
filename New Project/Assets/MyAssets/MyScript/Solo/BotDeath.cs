using UnityEngine;

public class BotDeath : MonoBehaviour
{
    public Rigidbody rb;
    public bool isOver;
    private Vector3 speed;
    private Quaternion rotPlayer;

    public void Start()
    {
        isOver = false;
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
        if (collision.gameObject.name == "Cube Solo(Clone)")
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

        if (collision.gameObject.name == "Player Solo(Clone)" || collision.gameObject.name == "'Bot'" || collision.gameObject.name == "BotNextLvl")
        {
            isOver = true;

            rb.GetComponent<Bot>().moveSpeed = 0;
            rb.isKinematic = true;
        }

        if (collision.collider.name == "Bonus1 Solo(Clone)" || collision.collider.name == "Bonus2 Solo(Clone)" || collision.collider.name == "Bonus3 Solo(Clone)" || collision.collider.name == "Bonus4 Solo(Clone)")
        {
            collision.collider.gameObject.SetActive(false);
            rb.transform.rotation = rotPlayer;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

