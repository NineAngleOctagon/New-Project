using UnityEngine;
using UnityEngine.Networking;

public class WallCreater : NetworkBehaviour {

    public Rigidbody rb;
    private TrailRenderer trail;
    public float gapTrail;
    private float tpsTrail;

    void Start ()
    {
        tpsTrail = Time.time + 1.0f;
	}
	
	void Update ()
    {

        trail = rb.GetComponent<TrailRenderer>();

        if (Time.time - tpsTrail >= gapTrail)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().mass = int.MaxValue;
            cube.GetComponent<Rigidbody>().useGravity = false;

            cube.transform.position = trail.GetPosition(trail.positionCount - 15);
            tpsTrail = Time.time;

            cube.GetComponent<Rigidbody>().isKinematic = true;

            cube.layer = 1;

            cube.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
