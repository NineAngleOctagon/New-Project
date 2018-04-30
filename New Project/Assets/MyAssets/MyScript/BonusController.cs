using UnityEngine;
using UnityEngine.Networking;

public class BonusController : NetworkBehaviour
{

    public Rigidbody rb;
    public GameObject bonus;

    public float gapBonus;
    private float tpsBonus;

    private void Start()
    {
        tpsBonus = Time.time + 0.5f;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Time.time - tpsBonus >= gapBonus && !rb.GetComponent<GameOver>().isOver)
        {
            float platform = Random.Range(0.0f, 3.0f);

            float posx;
            float posz;

            switch ((int) platform)
            {
                case 0:
                    posx = Random.Range(-75.0f, 75.0f);
                    posz = Random.Range(-75.0f, 75.0f);
                    break;
                case 1:
                    posx = Random.Range(-375.0f, -225.0f);
                    posz = Random.Range(-275.0f, -125.0f);
                    break;
                case 2:
                    posx = Random.Range(125.0f, 275.0f);
                    posz = Random.Range(-375.0f, -225.0f);
                    break;
                default:
                    posx = Random.Range(-70.0f, 70.0f);
                    posz = Random.Range(-70.0f, 70.0f);
                    break;
            }

            Vector3 position = new Vector3(posx, 0.5f, posz);

            Instantiate(bonus, position, Quaternion.identity);

            tpsBonus = Time.time;
        }
    }
}
