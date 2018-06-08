using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject restart;

	void Start ()
    {
        restart.SetActive(false);
	}
	
	void Update ()
    {
		if (rb.GetComponent<GameOverSolo>().isOver)
        {
            restart.SetActive(true);
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
