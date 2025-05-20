using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ShopObj;
    [SerializeField] GameObject SessionsObj;
    [SerializeField] GameObject SettingObj;
    [SerializeField] GameObject HelpObj;
    [SerializeField] GameObject NameObj;
    public void StartGame()
    {
        if (SessionsProfile.Instance.Sessions.Count == 0)
        {
            NameObj.SetActive(true);
            gameObject.SetActive(false);
        }
        else
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
}
