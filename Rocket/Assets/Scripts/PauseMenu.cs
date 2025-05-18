using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseEndPanel;
    public Player player;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            PauseGame();
        if (player.health <= 0.00001)
            PauseEndGame();
    }

    public void PauseGame() 
    {
        if (PausePanel != null)
            PausePanel.SetActive(true);
        Pause();
    }

    public void PauseEndGame() {
        if (PauseEndPanel != null)
            PauseEndPanel.SetActive(true);
        Pause();
    }


    public void UnpauseGame()
    {
        if (PausePanel != null)
            PausePanel.SetActive(false);
        Unpause();
    }
    public void EndGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    private void Pause() 
    {
        Time.timeScale = 0;
        isPaused = true;
    }
    private void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
    }


}
