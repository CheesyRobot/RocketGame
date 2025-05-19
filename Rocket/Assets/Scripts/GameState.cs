using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameState : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseBreakPanel;
    public GameObject EndPanel;
    
    public Player player;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            PauseGame();
        if (player.health <= 0.00001 && !isPaused)
            PauseEndGame();
    }

    private void PauseGame() 
    {
        if (PausePanel != null)
            PausePanel.SetActive(true);
        Pause();
    }

    private void PauseEndGame() {
        if (PauseBreakPanel != null)
            PauseBreakPanel.SetActive(true);
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
        PauseBreakPanel.SetActive(false);
        PausePanel.SetActive(false);
        EndPanel.SetActive(true);
        //Unpause();
        StartCoroutine("End");
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

    IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(2);
        //EndPanel.SetActive(false);
        Unpause();
        SceneManager.LoadScene(0);
    }
}
