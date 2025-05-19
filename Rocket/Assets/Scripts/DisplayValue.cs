using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private string type;
    [SerializeField] private Player player;

    void Update() {
        switch (type) {
            case "Coins":
                tmp.text = player.coinsCollected.ToString();
                break;
            case "Height":
                tmp.text = player.heightScore.ToString() + " m";
                break;
        }
    }

    public void Display(string text) {
        tmp.text = text;
    }
}
