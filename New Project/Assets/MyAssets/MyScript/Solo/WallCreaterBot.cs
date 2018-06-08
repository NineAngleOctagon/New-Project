using UnityEngine;

public class WallCreaterBot : MonoBehaviour
{
    public Rigidbody rb;
    private TrailRenderer trail;
    private int gapTrail;
    public int frequency;
    public int distance;
    public GameObject originalCube;
    public GameObject myBigCube;
    private bool bigWall;

    public bool isSafe = false;
    public float tpsSafe;

    private void Start()
    {
        gapTrail = 10;
        frequency = 2;
        distance = 10;
    }

    void Update()
    {
        bigWall = rb.GetComponent<Bot>().bigWall;
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

                cube.GetComponent<MeshRenderer>().enabled = true;

                isSafe = false;
                if (!bigWall)
                {
                    Instantiate(cube, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(cube, new Vector3(pos.x, pos.y + 2.5f, pos.z), Quaternion.identity);
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

