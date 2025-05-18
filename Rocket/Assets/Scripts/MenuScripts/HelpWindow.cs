using UnityEngine;
using TMPro;

public class HelpWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] TextMeshProUGUI Textbox;
    [SerializeField] TextAsset HelpText;
    string description = "test";

    public void Start()
    {
        SetDescription();
    }

    public void SetDescription()
    {
        description = HelpText.text;
        Textbox.text = description;
    }
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
