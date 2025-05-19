using UnityEngine;

public class UpgradeValue : Decorator
{
    float value = 0;
    public UpgradeValue(ShopUpgrade shopUpgrade, float value)
            : base(shopUpgrade)
    {
        this.value = value;
    }
    public override int UpgradeBought()
    {
        if (base.UpgradeBought() == -1) isSoldOut = true;
        return (int)value;
    }

    public override float GetValue()
    {
        return value;
    }
}

