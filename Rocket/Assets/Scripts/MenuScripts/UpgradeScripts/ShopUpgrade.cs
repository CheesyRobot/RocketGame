using UnityEngine;

public abstract class ShopUpgrade
{
    public string name;
    public string description;
    public int cost;
    public int level;
    public bool isSoldOut;
    public abstract int UpgradeBought();
    public abstract int GetCost();
    public abstract int GetValue();
    public abstract int GetLevel();
    public abstract bool IsSoldOut();
}
