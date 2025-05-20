using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameWindow : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    string rocketName;

    public void Awake()
    {
        inputName.text = "";
    }
    public void SaveName()
    {
        rocketName = inputName.text;
        RocketStartingProfile.Instance.playerName = rocketName;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
