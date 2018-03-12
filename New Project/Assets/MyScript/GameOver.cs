using UnityEngine;
using UnityEngine.Networking;

public class GameOver : MonoBehaviour {

    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube" || rb.position.y <= -15)
        {
            Destroy(rb.gameObject);
        }
    }
}
