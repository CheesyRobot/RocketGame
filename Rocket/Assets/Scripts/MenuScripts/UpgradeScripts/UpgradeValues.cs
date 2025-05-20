using UnityEngine;

public class UpgradeValues : Decorator
{
    float[] Values = { 1, 2, 3, 4, 5 };
    public UpgradeValues(ShopUpgrade shopUpgrade, float[] values)
            : base(shopUpgrade)
    {
        this.Values = values;
    }
    public override int UpgradeBought()
    {
        int index = base.UpgradeBought();
        if (index < Values.Length && index >= 0)
        {
            return index;
        }
        isSoldOut = true;
        return -1;
    }

    public override float GetValue()
    {
        int index = (int)base.GetValue();
        if (index < Values.Length && index >= 0)
        {
            return Values[index];
        }
        return -1;
    }
}

