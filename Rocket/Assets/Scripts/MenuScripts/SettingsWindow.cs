using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] Image FinsImage;
    public void RocketName()
    {

    }

    public void RocketColor(Button button)
    {
        Color rocketColor;
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
                rocketColor = Color.red;
                break;
        }
        FinsImage.color = rocketColor;
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
