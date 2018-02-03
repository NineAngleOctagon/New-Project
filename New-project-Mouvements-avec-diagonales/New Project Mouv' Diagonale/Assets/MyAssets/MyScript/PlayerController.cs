using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public Rigidbody rb;

	private float tps = 0;
	public float gap;
	public float moveSpeed;
	public float jumpForce;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer)
			return;

        if (Input.GetKey("d") && rb.position.y == 0.5 && Time.time - tps >= gap)
		{
            if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);                
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

		if (Input.GetKey("q") && rb.position.y == 0.5 && Time.time - tps >= gap)
		{
			if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
			{
				rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
			}
			else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
			{
				rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
			}
			else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
			{
				rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
			}
			else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
			{
				rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
			}
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey("e") && rb.position.y == 0.5 && Time.time - tps >= gap)
        {
            if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey("a") && rb.position.y == 0.5 && Time.time - tps >= gap)
        {
            if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, moveSpeed);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey(KeyCode.Space) && rb.position.y == 0.5)
		{
			rb.AddForce(0, jumpForce, 0);
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
