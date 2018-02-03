using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public Rigidbody rb; 

    public float moveSpeed;
    public float jumpForce;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        if (!isLocalPlayer)
            return;

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);

        Vector3 velocity = rb.velocity;

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
        }

        if (Input.GetKey("q"))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.Space) && rb.position.y == 0.5)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
