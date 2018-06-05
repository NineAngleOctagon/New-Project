using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameOverController : NetworkBehaviour {

    private bool isOver;
    private Camera PlayerCam;

    private void Start()
    {
        PlayerCam = GetComponent<GameOver>().PlayerCam;
    }

    void Update () {

        if (!isLocalPlayer)
            return;

        isOver = GetComponent<GameOver>().isOver;

        if (isOver)
        {
            if (Input.GetKey("[1]"))
                PlayerCam.transform.position = new Vector3(0, 150, 0);
            if (Input.GetKey("[2]"))
                PlayerCam.transform.position = new Vector3(-300, 150, -200);
            if (Input.GetKey("[3]"))
                PlayerCam.transform.position = new Vector3(200, 150, -300);
        }
	}
}
