using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame(int index)
    {
        SceneManager.LoadScene(index);
    }
}

