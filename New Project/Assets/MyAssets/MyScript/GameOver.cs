using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour {

    public Rigidbody rb;

    private void Update()
    {
        if (rb.position.y <= -15)
        {
            Destroy(rb.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            Destroy(rb.gameObject);
        }
    }
}
