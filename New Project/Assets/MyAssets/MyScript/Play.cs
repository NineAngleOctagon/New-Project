using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;

    public Dropdown numAI;
    public Dropdown diffAI;

    public void PlaySolo()
    {
        switch (numAI.value)
        {
            case 0:
                SceneManager.LoadScene("Training");
                break;
            case 1:
                if (diffAI.value == 0)
                    SceneManager.LoadScene("Solo1AI1");
                else
                    SceneManager.LoadScene("Solo1AI2");
                break;
            case 2:
                if (diffAI.value == 0)
                    SceneManager.LoadScene("Solo2AI1");
                else
                    SceneManager.LoadScene("Solo2AI2");
                break;
            default:
                if (diffAI.value == 0)
                    SceneManager.LoadScene("Solo3AI1");
                else
                    SceneManager.LoadScene("Solo3AI2");
                break;
        }
    }

    public void PlayMulti()
    {
        SceneManager.LoadScene("lobbyScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}