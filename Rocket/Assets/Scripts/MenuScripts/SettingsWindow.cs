using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] Image FinsImage;
    [SerializeField] TMP_InputField inputName;
    Color rocketColor = Color.red;
    string rocketName = "a";
    double volumeValue;
    RocketStartingProfile profile = RocketStartingProfile.GetInstance();

    private void Start()
    {
        rocketName = profile.playerName;
        rocketColor = profile.rocketColor;
        FinsImage.color = rocketColor;
        inputName.SetTextWithoutNotify(rocketName);
    }
    public void RocketName()
    {
        rocketName = inputName.text;
        profile.playerName = rocketName;
    }

    public void RocketColor(Button button)
    {
        Debug.Log(button.name);
        switch (button.name)
        {
            case "red":
                rocketColor = Color.red;
                break;
            case "blue":
                rocketColor = Color.blue;
                break;
            case "green":
                rocketColor = Color.green;
                break;
            case "cyan":
                rocketColor = Color.cyan;
                break;
            case "white":
                rocketColor = Color.white;
                break;
            case "black":
                rocketColor = Color.black;
                break;
            case "gray":
                rocketColor = Color.gray;
                break;
            case "magenta":
                rocketColor = Color.magenta;
                break;
            case "yellow":
                rocketColor = Color.yellow;
                break;
            default:
                break;
        }
        FinsImage.color = rocketColor;
        profile.rocketColor = rocketColor;
    }

    public void Volume()
    {

    }

    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
