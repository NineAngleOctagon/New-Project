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

    public Text winText;

    //A partir de là, c'est un test pour la mort
    float time = 2.0f;
    int rate = 10;

    private Vector3[] arv3;
    private int head;
    private int tail = 0;
    private float sliceTime = 1.0f / 10f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);

        winText.text = "";

        //Same : Je crois que je crée un tableau avec toutes les positions de mon trail
        arv3 = new Vector3[(Mathf.RoundToInt(time * rate)  + 1)];

        for (var i = 0; i < arv3.Length; i++)
            arv3[i] = transform.position;
        head = arv3.Length - 1;
        StartCoroutine(Collectdata());
	}

	void FixedUpdate ()
	{
        if (!isLocalPlayer)
        {
            PlayerCam.enabled = false;
            return;
        }

        if (Hit())
        {
            winText.text = "GG";
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
    }

    //Test Trail Collider : pas compris cette fonction mais je crois qu'elle collecte à chaque frame les nvelles positions du trail
    private IEnumerator Collectdata()
    {
        while (true)
        {
            if (transform.position != arv3[head])
            {
                head = (head + 1) % arv3.Length;
                tail = (tail + 1) % arv3.Length;
                arv3[head] = transform.position;
            }
            yield return new WaitForSeconds(sliceTime);
        }
    }

    //Je suppose que cette fonction vérifie si le player est sur une des positions
    private bool Hit()
    {
        var i = head;
        var j = (head - 1);
        if (j < 0)
        {
            j = arv3.Length - 1;
        }

        while (j != head)
        {
            if (Physics.Linecast(arv3[i], arv3[j]))
                return true;
            i--;
            if (i < 0)
                i = arv3.Length - 1;
            j--;
            if (j < 0)
                j = arv3.Length - 1;
        }

        return false;
    }
}
