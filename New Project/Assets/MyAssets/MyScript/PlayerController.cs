using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public Rigidbody rb;

	private float tps = 0;
	public float gap;
	public float moveSpeed;
	public float jumpForce;
    public Camera PlayerCam;
    public Vector3 north;
    public Vector3 south;
    public Vector3 west;
    public Vector3 east;
    public Vector3 north_East;
    public Vector3 north_West;
    public Vector3 south_East;
    public Vector3 south_West;
    
    void Start()    
	{
        float factor = Mathf.Sqrt(2) / 2;
        rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        north = new Vector3(0, rb.velocity.y, moveSpeed);
        south = new Vector3(0, rb.velocity.y, -moveSpeed);
        west = new Vector3(-moveSpeed, rb.velocity.y, 0);
        east = new Vector3(moveSpeed, rb.velocity.y, 0);
        north_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor* moveSpeed);
        north_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
        south_East = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
        south_West = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
    }

	void FixedUpdate ()
	{
        if (!isLocalPlayer)
        {
            PlayerCam.enabled = false;
            return;
        }
        float factor = Mathf.Sqrt(2) / 2;

        if (!rb.GetComponent<GameOver>().isOver)
        {
            if (Input.GetKey("d") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, 90, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north_East;
                }
                tps = Time.time;
            }

            if (Input.GetKey("q") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, -90, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = north_East;
                }
                tps = Time.time;
            }

            if (Input.GetKey("e") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, 45, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = north_East;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = north;
                }
                tps = Time.time;
            }

            if (Input.GetKey("a") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                transform.Rotate(0, -45, 0);
                if (rb.velocity == north)
                {
                    rb.velocity = north_West;
                }
                else if (rb.velocity == north_West)
                {
                    rb.velocity = west;
                }
                else if (rb.velocity == west)
                {
                    rb.velocity = south_West;
                }
                else if (rb.velocity == south_West)
                {
                    rb.velocity = south;
                }
                else if (rb.velocity == south)
                {
                    rb.velocity = south_East;
                }
                else if (rb.velocity == south_East)
                {
                    rb.velocity = east;
                }
                else if (rb.velocity == east)
                {
                    rb.velocity = north_East;
                }
                else if (rb.velocity == north_East)
                {
                    rb.velocity = north;
                }
                tps = Time.time;
            }

            if (Input.GetKey(KeyCode.Space) && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
            {
                rb.AddForce(0, jumpForce, 0);
            }
        }
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
        GetComponent<TrailRenderer>().material.color = Color.blue;
    }
}
