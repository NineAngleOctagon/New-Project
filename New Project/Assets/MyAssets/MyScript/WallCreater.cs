using UnityEngine;
using UnityEngine.Networking;

public class WallCreater : NetworkBehaviour
{

    public Rigidbody rb;
    private TrailRenderer trail;
    private int gapTrail;

    private void Start()
    {
        gapTrail = 6;
    }
    void Update()
    {
        trail = rb.GetComponent<TrailRenderer>();

        if (trail.positionCount > gapTrail)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.AddComponent<Rigidbody>();
            cube.AddComponent<NetworkIdentity>();
            cube.GetComponent<Rigidbody>().mass = int.MaxValue;
            cube.GetComponent<Rigidbody>().useGravity = false;

            cube.transform.position = trail.GetPosition(trail.positionCount - 6);
            gapTrail = trail.positionCount + 2;

            cube.GetComponent<Rigidbody>().isKinematic = true;

            cube.layer = 1;

            cube.GetComponent<MeshRenderer>().enabled = false;

            if (rb.GetComponent<PlayerController>().bigWall)
            {
                cube.transform.localScale = new Vector3(1.0f, 5.0f, 1.0f);
                cube.transform.position = new Vector3(cube.transform.position.x, 2.0f, cube.transform.position.z);
            }
        }
    }
}
