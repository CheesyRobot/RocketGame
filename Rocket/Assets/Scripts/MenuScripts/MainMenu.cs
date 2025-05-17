using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        Debug.Log("Shop button");
    }

    public void Sessions()
    {
        Debug.Log("Sessions button");
    }

    public void Settings()
    {
        Debug.Log("Settings button");
    }

    public void Help()
    {
        Debug.Log("Help button");
    }

    public void Exit()
    {
        Debug.Log("Exit button");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
