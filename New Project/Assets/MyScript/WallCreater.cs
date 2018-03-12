using UnityEngine;
using UnityEngine.Networking;

public class WallCreater : NetworkBehaviour {

    public Rigidbody rb;
    private TrailRenderer trail;
    public int moveSpeed;
    private float gapTrail;
    private float tpsTrail;

    void Start ()
    {
        tpsTrail = Time.time + 1.0f;
        gapTrail = 0.045f;
	}
	
	void Update ()
    {

        trail = rb.GetComponent<TrailRenderer>();
        float factor = Mathf.Sqrt(2) / 2;

        if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
        {
            gapTrail = 0.05f;
        }
        else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
        {
            gapTrail = 0.05f;
        }
        else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
        {
            gapTrail = 0.05f;
        }
        else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
        {
            gapTrail = 0.05f;
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            gapTrail = 0.08f;
        }
        else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            gapTrail = 0.08f;
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
        {
            gapTrail = 0.08f;
        }
        else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
        {
            gapTrail = 0.08f;
        }

        if (Time.time - tpsTrail >= gapTrail)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().mass = int.MaxValue;
            cube.GetComponent<Rigidbody>().useGravity = false;
            cube.transform.position = trail.GetPosition(trail.positionCount - 6);
            tpsTrail = Time.time;
        }
    }
}
