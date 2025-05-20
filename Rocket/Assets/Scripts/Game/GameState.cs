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
            Pause();
        if (player.health <= 0.00001 && !isPaused)
            PauseBreak();
    }

    public void Pause() 
    {
        if (PausePanel != null)
            PausePanel.SetActive(true);
        PauseTime();
    }

    public void PauseBreak() {
        if (PauseBreakPanel != null)
            PauseBreakPanel.SetActive(true);
        PauseTime();
    }


    public void Unpause()
    {
        if (PausePanel != null)
            PausePanel.SetActive(false);
        UnpauseTime();
    }
    public void Quit()
    {
        PauseBreakPanel.SetActive(false);
        PausePanel.SetActive(false);
        EndPanel.SetActive(true);
        RocketStartingProfile p = RocketStartingProfile.Instance;
        p.money += player.coinsCollected;
        SessionsProfile.Instance.AddSession(p.playerName, player.heightScore, player.coinsCollected);
        //Unpause();
        StartCoroutine("End"); 
    }

    private void PauseTime() 
    {
        Time.timeScale = 0;
        isPaused = true;
        player.Move();
    }
    private void UnpauseTime()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(2);
        //EndPanel.SetActive(false);
        UnpauseTime();
        SceneManager.LoadScene(0);
    }
}
