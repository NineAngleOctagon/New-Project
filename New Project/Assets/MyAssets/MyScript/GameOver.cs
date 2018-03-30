using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour {

    public Rigidbody rb;
    public Camera PlayerCam;
    public Camera EndCam;
    public bool isOver;

    private int[,] board;
    private TrailRenderer trail;
    private float tpsTrail;

    private void Start()
    {
        tpsTrail = Time.time + 0.12f;
        board = new int[300, 300];
        for (int i = 0; i < 300; i++)
        {
            for (int j = 0; j < 300; j++)
            {
                board[i, j] = -1;
            }
        }
    }

    private void Update()
    {
        if (board[(int) rb.transform.position.x + 150, (int) rb.transform.position.z + 150] == (int) rb.transform.position.y && !isOver)
        {
            isOver = true;

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.enabled = false;

            EndCam.transform.position = new Vector3(0, 176, 0);
            EndCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
            EndCam.enabled = true;
        }

        if (Time.time >= tpsTrail)
        {
            trail = rb.GetComponent<TrailRenderer>();

            board[(int) trail.GetPosition(trail.positionCount - 5).x + 150, (int) trail.GetPosition(trail.positionCount - 5).z + 150] = (int) trail.GetPosition(trail.positionCount - 5).y;
        }
    }
}
