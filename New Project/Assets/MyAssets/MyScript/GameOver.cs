using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour {

    public Rigidbody rb;
    public Camera PlayerCam;
    public bool isOver;

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        if (rb.position.y <= -1)
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
            isOver = true;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (collision.gameObject.name == "Player(Clone)")
        {
            isOver = true;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }
    }
}
