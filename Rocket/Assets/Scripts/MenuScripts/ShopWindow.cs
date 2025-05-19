using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] Transform UpgradeHolder;
    [SerializeField] GameObject UpgradeObj;
    List<ShopUpgrade> UpgradeList = new();

    public void Start()
    {
        InitializeUpgrades();
        DisplayUpgrades(UpgradeList);
        //GetComponentInChildren<>
    }

    public void InitializeUpgrades()
    {
        ShopUpgrade test = new Upgrade();
        UpgradeList.Add(test);
        UpgradeList.Add(new Upgrade("antra", "wee", 120, false));
    }

    public void DisplayUpgrades(List<ShopUpgrade> UpgradeList)
    {
        GameObject newUpgrade;
        foreach (ShopUpgrade upg in UpgradeList)
        {
            newUpgrade = Instantiate(UpgradeObj, UpgradeHolder);
            TextMeshProUGUI[] text = newUpgrade.GetComponentsInChildren<TextMeshProUGUI>();
            text[0].SetText(upg.name);
            text[1].SetText(upg.description);
            text[3].SetText($"{upg.GetCost()}");
            text[5].SetText($"{upg.GetLevel()}");
        }
    }
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
