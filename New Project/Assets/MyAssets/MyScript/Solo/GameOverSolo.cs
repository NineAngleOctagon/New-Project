﻿using UnityEngine;

public class GameOverSolo : MonoBehaviour
{
    public Rigidbody rb;
    public Camera PlayerCam;
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
        speed = rb.velocity;
        rotPlayer = rb.transform.rotation;

        if (!isOver && (rb.position.y <= -2 || Input.GetKey("m")))
        {
            isOver = true;

            rb.GetComponent<PlayerControllerSolo>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (!isOver && (Time.time - rb.GetComponent<WallCreaterSolo>().tpsSafe >= 5.0f && rb.GetComponent<WallCreaterSolo>().isSafe))
        {
            isOver = true;

            rb.GetComponent<PlayerControllerSolo>().moveSpeed = 0;
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
                bool playerzero = players[0].GetComponent<GameOverSolo>().isOver;
                bool playerone = players[1].GetComponent<BotDeath>().isOver;

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
                bool playerzero = players[0].GetComponent<GameOverSolo>().isOver;
                bool playerone = players[1].GetComponent<BotDeath>().isOver;
                bool playertwo = players[2].GetComponent<BotDeath>().isOver;

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
                bool playerzero = players[0].GetComponent<GameOverSolo>().isOver;
                bool playerone = players[1].GetComponent<BotDeath>().isOver;
                bool playertwo = players[2].GetComponent<BotDeath>().isOver;
                bool playerthree = players[3].GetComponent<BotDeath>().isOver;

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
        if (!isOver && (collision.gameObject.name == "Cube Solo(Clone)" || collision.gameObject.name == "BigCube Solo(Clone)"))
        {
            if (!rb.GetComponent<PlayerControllerSolo>().ghostBonus)
            {
                isOver = true;

                rb.GetComponent<PlayerControllerSolo>().moveSpeed = 0;
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

        if (!isOver && (collision.gameObject.name == "Player Solo(Clone)" || collision.gameObject.name == "'Bot'" || collision.gameObject.name == "BotNextLvl"))
        {
            isOver = true;

            rb.GetComponent<PlayerControllerSolo>().moveSpeed = 0;
            rb.isKinematic = true;

            PlayerCam.transform.position = new Vector3(0, 150, 0);
            PlayerCam.transform.rotation = new Quaternion(0f, -0.7071f, 0.7071f, 0f);
        }

        if (collision.collider.name == "Bonus1 Solo(Clone)" || collision.collider.name == "Bonus2 Solo(Clone)" || collision.collider.name == "Bonus3 Solo(Clone)" || collision.collider.name == "Bonus4 Solo(Clone)")
        {
            collision.collider.gameObject.SetActive(false);
            rb.transform.rotation = rotPlayer;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnGUI()
    {
        if (first)
        {
            if (numbers == 1)
            {

                GUI.skin.box = rb.GetComponent<InterfaceSolo>().Normalskin.box;
                GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you won but it wasn't that hard you know");
            }
            else
            {

                GUI.skin.box = rb.GetComponent<InterfaceSolo>().Normalskin.box;
                GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you won");
            }
        }
        if (second)
        {

            GUI.skin.box = rb.GetComponent<InterfaceSolo>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you nearly won");
        }
        if (third)
        {

            GUI.skin.box = rb.GetComponent<InterfaceSolo>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you nearly lost");
        }
        if (last)
        {

            GUI.skin.box = rb.GetComponent<InterfaceSolo>().Normalskin.box;
            GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 100), "you are bad");
        }
    }
}

