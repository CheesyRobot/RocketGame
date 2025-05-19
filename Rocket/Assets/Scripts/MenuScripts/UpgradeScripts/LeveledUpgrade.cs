using UnityEngine;

public class LeveledUpgrade : Decorator
{
    int maxLevel = 0;
    public LeveledUpgrade(ShopUpgrade shopUpgrade, int level,
            int maxLevel) : base(shopUpgrade)
    {
        this.level = level;
        this.maxLevel = maxLevel;
        if (level >= maxLevel)
            isSoldOut = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Current level number</returns>
    public override int UpgradeBought()
    {
        level++;
        if (level >= maxLevel)
        {
            isSoldOut = true;
            return -1;
        }
        return level;
    }

    public override int GetValue()
    {
        return level;
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

