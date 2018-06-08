using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Restart : NetworkBehaviour
{
    public GameObject restart;
    public GameObject MenuButton;
    public GameObject PlayAgainButton;
    private GameObject[] players;

    private bool tmp;
    private bool done;
    private int numbers;

    void Start ()
    {
        tmp = false;
        done = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        numbers = players.Length;
    }
	
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        if (done)
        {
            if (numbers == 4)
                tmp = players[0].GetComponent<GameOver>().isOver && players[1].GetComponent<GameOver>().isOver && players[2].GetComponent<GameOver>().isOver && players[3].GetComponent<GameOver>().isOver;

            if (numbers == 3)
                tmp = players[0].GetComponent<GameOver>().isOver && players[1].GetComponent<GameOver>().isOver && players[2].GetComponent<GameOver>().isOver;

            if (numbers == 2)
                tmp = players[0].GetComponent<GameOver>().isOver && players[1].GetComponent<GameOver>().isOver;

            if (numbers == 1)
                tmp = players[0].GetComponent<GameOver>().isOver;
        }

        if (tmp)
        {
            Instantiate(restart);
            Instantiate(MenuButton);
            Instantiate(PlayAgainButton);
            tmp = false;
            done = false;
        }
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
