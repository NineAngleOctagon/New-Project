using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTraining : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject restart;

    void Start()
    {
        restart.SetActive(false);
    }

    void Update()
    {
        if (rb.GetComponent<GameOverTraining>().isOver)
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

