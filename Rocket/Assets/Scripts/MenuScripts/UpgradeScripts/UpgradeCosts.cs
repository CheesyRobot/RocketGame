using UnityEngine;

public class UpgradeCosts : Decorator
{
    int[] CostValues;
    public UpgradeCosts(ShopUpgrade shopUpgrade,
            int[] costValues) : base(shopUpgrade)
    {
        this.CostValues = costValues;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Current index</returns>
    public override int UpgradeBought()
    {
        return ChangeCost(base.UpgradeBought());
    }

    /// <returns>Current index</returns>
    public override float GetValue()
    {
        return base.GetValue();
    }

    public override int GetCost()
    {
        int index = base.GetLevel();
        if (index < CostValues.Length && index >= 0)
        {
            return CostValues[index];
        }
        return -1;
    }

    public int ChangeCost(int i)
    {
        if (i < CostValues.Length && i >= 0)
        {
            cost = CostValues[i];
            return i;
        }
        isSoldOut = true;
        return -1;
    }
}

