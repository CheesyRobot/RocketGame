using UnityEngine;

public abstract class ShopUpgrade
{
    public string Name;
    public string Description;
    public int cost;
    public int level;
    public bool isSoldOut;
    public abstract int UpgradeBought();
    public abstract string GetName();
    public abstract string GetDescription();
    public abstract int GetCost();
    public abstract float GetValue();
    public abstract int GetLevel();
    public abstract bool IsSoldOut();
}
