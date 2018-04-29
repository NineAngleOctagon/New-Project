using UnityEngine;
using UnityEngine.Networking;

public class WallCreater : NetworkBehaviour
{

    public Rigidbody rb;
    private TrailRenderer trail;
    public float gapTrail;
    private float tpsTrail = 0;

    void Update()
    {

        trail = rb.GetComponent<TrailRenderer>();

        if (trail.positionCount > 5 && Time.time - tpsTrail >= gapTrail)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.AddComponent<Rigidbody>();
            cube.AddComponent<NetworkIdentity>();
            cube.GetComponent<Rigidbody>().mass = int.MaxValue;
            cube.GetComponent<Rigidbody>().useGravity = false;

            cube.transform.position = trail.GetPosition(trail.positionCount - 6);
            tpsTrail = Time.time;

            cube.GetComponent<Rigidbody>().isKinematic = true;

            cube.layer = 1;

            cube.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
