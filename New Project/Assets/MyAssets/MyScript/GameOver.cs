using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour {

    public Rigidbody rb;

    private void Update()
    {
        if (rb.position.y <= -15)
        {
            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.GetComponent<WallCreater>().gapTrail = float.MaxValue;
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.GetComponent<WallCreater>().gapTrail = float.MaxValue;
            rb.isKinematic = true;
        }
    }
}
