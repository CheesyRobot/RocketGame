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
        ShopObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Sessions()
    {
        SessionsObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Settings()
    {
        SettingObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Help()
    {
        HelpObj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
