using UnityEngine;
using UnityEngine.Networking;

public class WallCreater : NetworkBehaviour
{
    public Rigidbody rb;
    private TrailRenderer trail;
    private int gapTrail;
    public int frequency;
    public int distance;
    public GameObject originalCube;
    public GameObject myBigCube;

    public bool isSafe = false;
    public float tpsSafe;

    private void Start()
    {
        gapTrail = 6;
        frequency = 1;
        distance = 6;
    }
    void Update()
    {
        if (!isLocalPlayer)
            return;

        CmdSpawnBonus(rb.GetComponent<PlayerController>().bigWall);
    }

    [Command]
    void CmdSpawnBonus(bool bigWall)
    {
        trail = rb.GetComponent<TrailRenderer>();

        if (trail.positionCount > gapTrail)
        {
            GameObject cube = originalCube;

            if (bigWall)
            {
                cube = myBigCube;
            }

            Vector3 pos = trail.GetPosition(trail.positionCount - distance);

            if ((pos.x <= -15 || pos.x >= 15 || pos.z <= 45)
                && (pos.x <= -15 || pos.x >= 15 || pos.z >= -45)
                && (pos.x <= -315 || pos.x >= -285 || pos.z <= -155)
                && (pos.x <= -315 || pos.x >= -285 || pos.z >= -245)
                && (pos.x >= 177.5 || pos.x <= 147.5 || pos.z <= -255)
                && (pos.x >= 252.5 || pos.x <= 222.5 || pos.z <= -255)
                && pos.y <= 30)
            {
                gapTrail = trail.positionCount + frequency;

                cube.GetComponent<Rigidbody>().isKinematic = true;

                cube.layer = 1;

                cube.GetComponent<MeshRenderer>().enabled = false;

                isSafe = false;
                if (!bigWall)
                {
                    GameObject cubespawned = Instantiate(cube, pos, Quaternion.identity);
                    NetworkServer.Spawn(cubespawned);
                }
                else
                {
                    GameObject cubespawned = Instantiate(cube, new Vector3(pos.x, pos.y + 2.5f, pos.z), Quaternion.identity);
                    NetworkServer.Spawn(cubespawned);
                }
            }
            else
            {
                if (!isSafe)
                {
                    tpsSafe = Time.time;
                    isSafe = true;
                }
            }
        }
    }
}
