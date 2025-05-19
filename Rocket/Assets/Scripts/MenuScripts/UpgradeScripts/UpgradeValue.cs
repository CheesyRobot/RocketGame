using UnityEngine;

public class UpgradeValue : Decorator
{
    int value = 0;
    public UpgradeValue(ShopUpgrade shopUpgrade, int value)
            : base(shopUpgrade)
    {
        this.value = value;
    }
    public override int UpgradeBought()
    {
        if (base.UpgradeBought() == -1) isSoldOut = true;
        return value;
    }

    public override int GetValue()
    {
        return value;
    }
}

