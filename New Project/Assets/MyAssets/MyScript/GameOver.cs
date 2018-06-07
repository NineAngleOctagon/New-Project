using UnityEngine;
using UnityEngine.Networking;

public class GameOver : NetworkBehaviour
{
    public Rigidbody rb;
    public Camera PlayerCam;
    [SyncVar]
    public bool isOver;
    private Vector3 speed;
    private Quaternion rotPlayer;
    private GameObject[] players;
    private int numbers;
    private bool first;
    private bool second;
    private bool third;
    private bool last;

    private void Start()
    {
        first = false;
        second = false;
        third = false;
        last = false;
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;
        
        speed = rb.velocity;
        rotPlayer = rb.transform.rotation;

        if (!isOver && (rb.position.y <= -2 || Input.GetKey("m")))
        {
            CmdGameOver();

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (!isOver && (Time.time - rb.GetComponent<WallCreater>().tpsSafe >= 5.0f && rb.GetComponent<WallCreater>().isSafe))
        {
            CmdGameOver();

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (isOver && !first && !second && !third && !last)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            numbers = players.Length;

            if (numbers == 1)
            {
                first = true;
            }
            if (numbers == 2)
            {
                bool playerzero = players[0].GetComponent<GameOver>().isOver;
                bool playerone = players[1].GetComponent<GameOver>().isOver;

                if (playerzero && playerone)
                {
                    first = true;
                }
                else
                {
                    last = true;
                }
            }
            if (numbers == 3)
            {
                bool playerzero = players[0].GetComponent<GameOver>().isOver;
                bool playerone = players[1].GetComponent<GameOver>().isOver;
                bool playertwo = players[2].GetComponent<GameOver>().isOver;

                if (playerzero && playerone && playertwo)
                {
                    first = true;
                }
                else
                {
                    if ((playerzero && (playerone || playertwo))
                        || (playerone && (playerzero || playertwo))
                        || (playertwo && (playerzero || playerone)))
                    {
                        second = true;
                    }
                    else
                    {
                        last = true;
                    }
                }
            }
            if (numbers == 4)
            {
                bool playerzero = players[0].GetComponent<GameOver>().isOver;
                bool playerone = players[1].GetComponent<GameOver>().isOver;
                bool playertwo = players[2].GetComponent<GameOver>().isOver;
                bool playerthree = players[3].GetComponent<GameOver>().isOver;

                if (playerzero && playerone && playertwo && playerthree)
                {
                    first = true;
                }
                else
                {
                    if ((playerzero && playerone && (playertwo || playerthree))
                        || (playerzero && playertwo && (playerone || playerthree))
                        || (playerzero && playerthree && (playerone || playertwo))
                        || (playerone && playertwo && (playerzero || playerthree))
                        || (playerone && playerthree && (playerzero || playertwo))
                        || (playertwo && playerthree && (playerzero || playerone)))
                    {
                        second = true;
                    }
                    else
                    {
                        if ((playerzero && (playerone || playertwo || playerthree))
                            || (playerone && (playerzero || playertwo || playerthree))
                            || (playertwo && (playerzero || playerone || playerthree))
                            || (playerthree && (playerzero || playerone || playertwo)))
                        {
                            third = true;
                        }
                        else
                        {
                            last = true;
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer)
            return;

        if (!isOver && (collision.gameObject.name == "Cube(Clone)" || collision.gameObject.name == "BigCube(Clone)"))
        {
            if (!rb.GetComponent<PlayerController>().ghostBonus)
            {
                CmdGameOver();

                rb.GetComponent<PlayerController>().moveSpeed = 0;
                rb.isKinematic = true;

                PlayerCam.transform.position = new Vector3(0, 150, 0);
                PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
            }
            else
            {
                Destroy(collision.gameObject);
                rb.velocity = speed;
                rb.transform.rotation = rotPlayer;
                rb.angularVelocity = Vector3.zero;
            }
        }

        if (!isOver && (collision.gameObject.name == "Player(Clone)" || collision.gameObject.name == "'Bot'"))
        {
            CmdGameOver();

            rb.GetComponent<PlayerController>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (collision.collider.name == "Bonus1(Clone)" || collision.collider.name == "Bonus2(Clone)" || collision.collider.name == "Bonus3(Clone)" || collision.collider.name == "Bonus4(Clone)")
        {
            collision.collider.gameObject.SetActive(false);
            rb.transform.rotation = rotPlayer;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnGUI()
    {
        if (!isLocalPlayer)
            return;

        if(first)
        {
            if (numbers == 1)
            {
                
                GUI.skin.box = rb.GetComponent<Interface>().Normalskin.box;
                GUI.Box(new Rect(0 , Screen.height / 2, Screen.width, 100), "you won but it wasn't that hard you know");
            }
            else
            {

                GUI.skin.box = rb.GetComponent<Interface>().Normalskin.box;
                GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you won");
            }
        }
        if (second)
        {

            GUI.skin.box = rb.GetComponent<Interface>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you nearly won");
        }
        if (third)
        {

            GUI.skin.box = rb.GetComponent<Interface>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you nearly lost");
        }
        if (last)
        {

            GUI.skin.box = rb.GetComponent<Interface>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you are bad");
        }
    }

    [Command]
    void CmdGameOver()
    {
        this.isOver = true;
    }
}
