using UnityEngine;

public class Botlvl0 : MonoBehaviour
{
    public Rigidbody bot;
    private float moveSpeed;
    private float factor;
    private int rdm;
    public bool dodging;
    public float tps;

	void Start ()
    {
        factor = Mathf.Sqrt(2) / 2;
	}

    void Update()
    {
        if (dodging && (Time.time - tps >= 0.5f))
        {
            dodging = false;
            bot.GetComponent<Bot>().enabled = true;
            bot.GetComponent<Bot>().tmp = Time.time;
        }
    }
	
	void OnTriggerEnter (Collider collider) {
        moveSpeed = bot.GetComponent<Bot>().moveSpeed;
        rdm =(int) Random.Range(0, 2);
        if (!dodging && (bot.velocity == new Vector3(0, bot.velocity.y, moveSpeed) || bot.velocity == new Vector3(0, bot.velocity.y, -moveSpeed)))
        {
            dodging = true;
            bot.GetComponent<Bot>().enabled = false;
            tps = Time.time;
            switch (rdm)
            {
                case 0:
                    bot.velocity = new Vector3(moveSpeed, bot.velocity.y, 0);
                    break;
                default:
                    bot.velocity = new Vector3(-moveSpeed, bot.velocity.y, 0);
                    break;
            }
        }
        else if (!dodging && (bot.velocity == new Vector3(moveSpeed, bot.velocity.y, 0) || bot.velocity == new Vector3(-moveSpeed, bot.velocity.y, 0)))
        {
            dodging = true;
            bot.GetComponent<Bot>().enabled = false;
            tps = Time.time;
            switch (rdm)
            {
                case 0:
                    bot.velocity = new Vector3(0, bot.velocity.y, -moveSpeed);
                    break;
                default:
                    bot.velocity = new Vector3(0, bot.velocity.y, moveSpeed);
                    break;
            }
        }
        else if (!dodging && (bot.velocity == new Vector3(factor * moveSpeed, bot.velocity.y, factor * moveSpeed) || bot.velocity == new Vector3(factor * -moveSpeed, bot.velocity.y, factor * -moveSpeed)))
        {
            dodging = true;
            bot.GetComponent<Bot>().enabled = false;
            tps = Time.time;
            switch (rdm)
            {
                case 0:
                    bot.velocity = new Vector3(factor * moveSpeed, bot.velocity.y, factor * -moveSpeed);
                    break;
                default:
                    bot.velocity = new Vector3(factor * -moveSpeed, bot.velocity.y, factor * moveSpeed);
                    break;
            }
        }
        else if (!dodging && (bot.velocity == new Vector3(factor * moveSpeed, bot.velocity.y, factor * -moveSpeed) || bot.velocity == new Vector3(factor * -moveSpeed, bot.velocity.y, factor * moveSpeed)))
        {
            dodging = true;
            bot.GetComponent<Bot>().enabled = false;
            tps = Time.time;
            switch (rdm)
            {
                case 0:
                    bot.velocity = new Vector3(factor * -moveSpeed, bot.velocity.y, factor * -moveSpeed);
                    break;
                default:
                    bot.velocity = new Vector3(factor * moveSpeed, bot.velocity.y, factor * moveSpeed);
                    break;
            }
        }
    }
}
