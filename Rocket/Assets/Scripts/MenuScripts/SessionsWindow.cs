using UnityEngine;

public class SessionsWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;

    /*public void Start()
    {
        //GetComponentInChildren<>
    }*/
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
