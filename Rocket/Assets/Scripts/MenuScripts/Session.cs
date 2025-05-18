using UnityEngine;

public class Session
{
    public string PlayerName { get; }
    public int ReachedHeight { get; }
    public int GottenMoney { get; }

    public Session(string PlayerName, int GottenMoney, int ReachedHeight)
    {
        this.PlayerName = PlayerName;
        this.ReachedHeight = ReachedHeight;
        this.GottenMoney = GottenMoney;
    }
}
