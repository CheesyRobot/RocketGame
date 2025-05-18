using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SessionsWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] TextMeshProUGUI WindowName;
    [SerializeField] GameObject SessionRow;
    [SerializeField] GameObject SessionHolder;
    List<Session> Sessions = new List<Session>();

    public void Start()
    {
        //Testiniai duomenys
        AddSession("Vienas", 10, 822);
        AddSession("Du", 5, 125);
        AddSession("Trys", 15, 100);

        WindowName.SetText($"Hello {RocketStartingProfile.GetInstance().playerName}!");
        DisplaySessions();
    }

    public void AddSession(string PlayerName, int ReachedHeight, int GottenMoney)
    {
        Sessions.Insert(0, new Session(PlayerName, ReachedHeight, GottenMoney));
        if (Sessions.Count > 10)
        {
            Sessions.RemoveAt(10);
        }
    }

    public void DisplaySessions()
    {
        GameObject newSession;
        if(Sessions.Count == 0)
        {
            newSession = Instantiate(new GameObject(), SessionHolder.GetComponent<Transform>());
            TextMeshProUGUI noSessionsText = newSession.AddComponent<TextMeshProUGUI>();
            noSessionsText.SetText("There are currently no sessions");
            noSessionsText.textWrappingMode = 0;
            noSessionsText.margin = new Vector4( 10, 10, 10, 10 );
            return;
        }
        newSession = Instantiate(SessionRow, SessionHolder.GetComponent<Transform>());
        int count = 1;
        foreach (Session session in Sessions) {
            newSession = Instantiate(SessionRow, SessionHolder.GetComponent<Transform>());
            TextMeshProUGUI[] text = newSession.GetComponentsInChildren<TextMeshProUGUI>();
            text[0].SetText($"#{count++} {session.PlayerName}");
            text[1].SetText($"{session.GottenMoney}");
            text[2].SetText($"{session.ReachedHeight}");
        }

    }
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
