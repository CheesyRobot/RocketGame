using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SessionsProfile : MonoBehaviour
{
    private static SessionsProfile instance;

    public static SessionsProfile Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject().AddComponent<SessionsProfile>();
                instance.name = instance.GetType().ToString();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    
    public List<Session> Sessions { get; set; }

    private SessionsProfile()
    {
        Sessions = new List<Session>();
    }

    public void AddSession(string PlayerName, int ReachedHeight, int GottenMoney)
    {
        if (Sessions.Count == 0) {
            Sessions.Add(new Session(PlayerName, ReachedHeight, GottenMoney));
        }
        else
            Sessions.Insert(0, new Session(PlayerName, ReachedHeight, GottenMoney));

        if (Sessions.Count > 10)
        {
            Sessions.RemoveAt(10);
        }
    }

    public void Save(ref SessionsData data)
    {
        data.Sessions = new();
        foreach(Session ses in Sessions)
        {
            ASessionData newSession = new();
            newSession.PlayerName = ses.PlayerName;
            newSession.GottenMoney = ses.GottenMoney;
            newSession.ReachedHeight = ses.ReachedHeight;
            data.Sessions.Add(newSession);
        }
         
    }

    public void Load(SessionsData data)
    {
        foreach(ASessionData ses in data.Sessions)
        {
            Session newSession = new(ses.PlayerName, ses.GottenMoney, ses.ReachedHeight);
            Sessions.Add(newSession);
        }
    }
}

[System.Serializable]
public struct SessionsData
{
    public List<ASessionData> Sessions;
}

[System.Serializable]
public struct ASessionData
{
    public string PlayerName;
    public int ReachedHeight;
    public int GottenMoney;
}