using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;

    public void Start()
    {
        //GetComponentInChildren<>
    }
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
