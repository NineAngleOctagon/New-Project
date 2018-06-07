using UnityEngine;

public class GameOverControllerSolo : MonoBehaviour
{

    private bool isOver;
    private Camera PlayerCam;

    private void Start()
    {
        PlayerCam = GetComponent<GameOver>().PlayerCam;
    }

    void Update()
    {
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
