using UnityEngine;

class Upgrade : ShopUpgrade
{
    public Upgrade(string name, string description, int cost, bool isSoldOut)
    {
        this.name = name;
        this.description = description;
        this.cost = cost;
        this.isSoldOut = false;
        this.level = 0;
    }

    public Upgrade()
    {
        this.name = "name";
        this.description = "description";
        this.cost = 100;
        this.isSoldOut = false;
        this.level = 0;
    }
    public override int UpgradeBought()
    {
        isSoldOut = true;
        return cost;
    }

    public override int GetCost()
    {
        return cost;
    }

    public override int GetValue()
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
