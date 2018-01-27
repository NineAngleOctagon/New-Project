using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    //This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb; 

    public float forwardForce;
    public float sidewaysForce;
    public float jumpForce;
    
    void Start()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    }

    void FixedUpdate ()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce, 0, 0);
        }

        if (Input.GetKey("q"))
        {
            rb.AddForce(-sidewaysForce, 0, 0);
        }

        if (Input.GetKey("w") && rb.position.y == 0.5)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
