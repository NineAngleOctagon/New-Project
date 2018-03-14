using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour {

    public Rigidbody rb;
    public Camera PlayerCam;
    public Camera EndCam;
    public bool isOver;

    private void Update()
    {
        if (rb.position.y <= -15)
        {
            isOver = false;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.GetComponent<WallCreater>().gapTrail = float.MaxValue;
            rb.isKinematic = true;

            PlayerCam.enabled = false;

            EndCam.transform.position = new Vector3(0, 150, 0);
            EndCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
            EndCam.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            isOver = true;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.GetComponent<WallCreater>().gapTrail = float.MaxValue;
            rb.isKinematic = true;

            PlayerCam.enabled = false;

            EndCam.transform.position = new Vector3(0, 150, 0);
            EndCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
            EndCam.enabled = true;
        }
    }
}
