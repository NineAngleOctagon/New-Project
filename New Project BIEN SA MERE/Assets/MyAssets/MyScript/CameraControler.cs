using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraControler : NetworkBehaviour {
    public Rigidbody rb;
    public float gap;
    private float tps = 0;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("d")&& Time.time - tps >= gap)
        {
            transform.Rotate(0,-90,0, Space.World );
            tps = Time.time;
        }
        
		
	}
}
