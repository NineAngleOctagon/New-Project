using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour
{

    public Rigidbody rb;
    public Camera PlayerCam;
    public bool isOver;
    private Vector3 speed;
    private Quaternion rotPlayer;

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        speed = rb.velocity;
        rotPlayer = rb.transform.rotation;

        if (rb.position.y <= -2 || Input.GetKey("m"))
        {
            isOver = true;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer)
            return;

        if (collision.gameObject.name == "Cube")
        {
            if (!rb.GetComponent<PlayerController>().ghostBonus)
            {
                isOver = true;

                rb.GetComponent<PlayerController>().moveSpeed = 0;
                rb.isKinematic = true;

                PlayerCam.transform.position = new Vector3(0, 150, 0);
                PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
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

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (collision.collider.name == "Bonus1(Clone)" || collision.collider.name == "Bonus2(Clone)" || collision.collider.name == "Bonus3(Clone)" || collision.collider.name == "Bonus4(Clone)")
        {
            collision.collider.gameObject.SetActive(false);
            rb.transform.rotation = rotPlayer;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
