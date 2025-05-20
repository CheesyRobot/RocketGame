using UnityEngine;

public class Upgrade : ShopUpgrade
{
    public Upgrade(string name, string description, int cost, bool isSoldOut)
    {
        this.Name = name;
        this.Description = description;
        this.cost = cost;
        this.isSoldOut = false;
        this.level = 0;
    }

    public Upgrade()
    {
        this.Name = "name";
        this.Description = "description";
        this.cost = 100;
        this.isSoldOut = false;
        this.level = 0;
    }
    public override int UpgradeBought()
    {
        isSoldOut = true;
        level = 1;
        return cost;
    }

    public override string GetName()
    {
        return Name;
    }

    public override string GetDescription()
    {
        return Description;
    }

    public override int GetCost()
    {
        return cost;
    }

    public override float GetValue()
    {
        return isSoldOut ? 1 : -1;
    }

    public override int GetLevel()
    {
        return level;
    }

    public override bool IsSoldOut()
    {
        return isSoldOut;
    }
}
