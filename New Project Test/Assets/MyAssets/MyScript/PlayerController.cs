using UnityEngine;

public class PlayerController : MonoBehaviour {

    //This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce;

    void Start()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
    }

    // We marked this as "FixedPoint" before we are using it to mess with physics
    void FixedUpdate ()
    {
        
  	}
}
