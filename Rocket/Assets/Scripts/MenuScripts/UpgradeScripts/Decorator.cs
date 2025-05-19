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

    public override int GetCost()
    {
        return shopUpgrade.GetCost();
    }

    public override int GetValue()
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
