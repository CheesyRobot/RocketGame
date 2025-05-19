using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ShopObj;
    [SerializeField] GameObject SessionsObj;
    [SerializeField] GameObject SettingObj;
    [SerializeField] GameObject HelpObj;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        Debug.Log("Shop button");
        ShopObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Sessions()
    {
        Debug.Log("Sessions button");
        SessionsObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        Debug.Log("Settings button");
        SettingObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Help()
    {
        Debug.Log("Help button");
        HelpObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Exit button");
        Application.Quit();
    }

    private void Update()
    {
        if (Keyboard.current.numpad0Key.wasPressedThisFrame)
        {
            SaveSystem.Save();
            Debug.Log(RocketStartingProfile.GetInstance().playerName);
            Debug.Log("Saved");
        }

        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            SaveSystem.Load();
            Debug.Log("Loaded");
            Debug.Log(RocketStartingProfile.GetInstance().playerName);
        }
    }
}
