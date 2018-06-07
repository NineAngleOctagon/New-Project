using UnityEngine;

public class Botlvl1 : MonoBehaviour
{
    public Rigidbody bot;
    public float tps;
    public bool turning;
	
	void Update ()
    {
		if (!turning && (bot.transform.position.x > 70 || bot.transform.position.x < -70) && !(bot.velocity == new Vector3(0, bot.velocity.y, bot.GetComponent<Bot>().moveSpeed)))
        {
            bot.velocity = new Vector3(0, bot.velocity.y, bot.GetComponent<Bot>().moveSpeed);
            tps = Time.time;
            turning = true;
            bot.GetComponent<Bot>().enabled = false;
        }

        if (turning && Time.time - tps >= 0.1f && bot.transform.position.x > 70 && bot.velocity == new Vector3(0, bot.velocity.y, bot.GetComponent<Bot>().moveSpeed))
        {
            bot.velocity = new Vector3(-bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0);
        }
        else if (turning && Time.time - tps >= 0.1f && bot.transform.position.x < -70 && bot.velocity == new Vector3(0, bot.velocity.y, bot.GetComponent<Bot>().moveSpeed))
        {
            bot.velocity = new Vector3(bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0);
        }

        if (!turning && bot.transform.position.z > 70 || bot.transform.position.z < -70 && !(bot.velocity == new Vector3(bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0)))
        {
            bot.velocity = new Vector3(bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0);
            tps = Time.time;
            turning = true;
            bot.GetComponent<Bot>().enabled = false;
        }

        if (turning && Time.time - tps >= 0.1f && bot.transform.position.z > 70 && bot.velocity == new Vector3(bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0))
        {
            bot.velocity = new Vector3(0, bot.velocity.y, -bot.GetComponent<Bot>().moveSpeed);
        }
        else if (turning && Time.time - tps >= 0.1f && bot.transform.position.z < -70 && bot.velocity == new Vector3(bot.GetComponent<Bot>().moveSpeed, bot.velocity.y, 0))
        {
            bot.velocity = new Vector3(0, bot.velocity.y, bot.GetComponent<Bot>().moveSpeed);
        }

        if (turning && Time.time - tps > 0.2f)
        {
            turning = false;
            bot.GetComponent<Bot>().enabled = true;
            bot.GetComponent<Bot>().tmp = Time.time;
        }
    }
}
