using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

	public Rigidbody rb;

	private float tps = 0;
	public float gap;
	public float moveSpeed;
	public float jumpForce;
    public Camera PlayerCam;

    void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
    }

	void FixedUpdate ()
	{
        if (!isLocalPlayer)
        {
            PlayerCam.enabled = false;
            return;
        }

        float factor = Mathf.Sqrt(2) / 2;

        if (Input.GetKey("d") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
		{
            transform.Rotate(0, 90, 0);
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
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            tps = Time.time;
        }

		if (Input.GetKey("q") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
		{
            transform.Rotate(0, -90, 0);
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
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey("e") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
        {
            transform.Rotate(0, 45, 0);
            if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey("a") && Time.time - tps >= gap && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
        {
            transform.Rotate(0, -45, 0);
            if (rb.velocity == new Vector3(0, rb.velocity.y, moveSpeed))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(-moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * -moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, -moveSpeed);
            }
            else if (rb.velocity == new Vector3(0, rb.velocity.y, -moveSpeed))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * -moveSpeed))
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            }
            else if (rb.velocity == new Vector3(moveSpeed, rb.velocity.y, 0))
            {
                rb.velocity = new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed);
            }
            else if (rb.velocity == new Vector3(factor * moveSpeed, rb.velocity.y, factor * moveSpeed))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
            }
            tps = Time.time;
        }

        if (Input.GetKey(KeyCode.Space) && rb.position.y >= 0.49999 && rb.position.y <= 0.50001)
		{
			rb.AddForce(0, jumpForce, 0);
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
        GetComponent<TrailRenderer>().material.color = Color.blue;
    }
}
