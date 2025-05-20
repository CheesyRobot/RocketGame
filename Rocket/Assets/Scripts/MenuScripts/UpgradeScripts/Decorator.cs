using UnityEngine;

public class Decorator : ShopUpgrade
{
    private ShopUpgrade shopUpgrade;
    public Decorator(ShopUpgrade shopUpgrade)
    {
        this.shopUpgrade = shopUpgrade;
    }
    public override int UpgradeBought()
    {
        return shopUpgrade.UpgradeBought();
    }

    public override string GetName()
    {
        return shopUpgrade.GetName();
    }

    public override string GetDescription()
    {
        return shopUpgrade.GetDescription();
    }

    public override int GetCost()
    {
        return shopUpgrade.GetCost();
    }

    public override float GetValue()
    {
        return shopUpgrade.GetValue();
    }

    public override int GetLevel()
    {
        return shopUpgrade.GetLevel();
    }

    public override bool IsSoldOut()
    {
        return shopUpgrade.IsSoldOut();
    }
}
