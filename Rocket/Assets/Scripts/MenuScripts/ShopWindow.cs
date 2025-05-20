using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] Transform UpgradeHolder;
    [SerializeField] GameObject UpgradeObj;
    [SerializeField] TextMeshProUGUI money;
    public List<UpgradeDataObject> Upgrades;
    List<ShopUpgrade> UpgradeList = new();

    public void Start()
    {
        InitializeUpgrades();
        DisplayUpgrades(UpgradeList);
        money.SetText($"{RocketStartingProfile.Instance.money}");
    }

    public void InitializeUpgrades()
    {
        /*
        0. Armor - apsaugo nuo susidūrimų. 3 lygiai.
        1. Engine - lemia išvystomą pagreitį. 3 lygiai.
        2. Flaps - sukimosi greitis ir stabdymas. 2 lygiai.
        3. Head - lemia maksimalų raketos greitį. 3 lygiai.
        4. Fuel storage - lemia maksimalią kuro talpą. 5 lygiai.
        5. Rocket engineer - pasyviai ir pastoviai prideda būklės taškų per laiko vienetą.*/
        int[] levels = (RocketStartingProfile.Instance.UpgradeLevels.Count == 0 || 
            RocketStartingProfile.Instance.UpgradeLevels == null)? new int[Upgrades.Count]: RocketStartingProfile.Instance.UpgradeLevels.ToArray();
        UpgradeDataObject dat = Upgrades.ElementAt(0);
        ShopUpgrade test = new Upgrade(dat.Name, dat.Description, dat.cost, dat.isSoldOut);
        test = new UpgradeValue(new LeveledUpgrade(test, levels[0], dat.maxLevel), dat.Values[0]);
        UpgradeList.Add(test);
        for(int i = 1; i < 4; i++)
        {
            dat = Upgrades.ElementAt(i);
            test = new Upgrade(dat.Name, dat.Description,
                dat.cost, dat.isSoldOut);
            test = new UpgradeCosts(new UpgradeValues(new LeveledUpgrade(test, levels[i], dat.maxLevel),
                dat.Values), dat.Costs);
            UpgradeList.Add(test);
        }
        //4. Fuel storage.
        dat = Upgrades.ElementAt(4);
        test = new Upgrade(dat.Name, dat.Description,
            dat.cost, dat.isSoldOut);
        test = new UpgradeCosts(new UpgradeValue(new LeveledUpgrade(test, levels[4], dat.maxLevel),
            dat.Values[0]), dat.Costs);
        UpgradeList.Add(test);
        //5.Rocket engineer.
        dat = Upgrades.ElementAt(5);
        test = new Upgrade(dat.Name, dat.Description,
            dat.cost, (levels[5] == 0)?false:true);
        UpgradeList.Add(test);
    }

    public void DisplayUpgrades(List<ShopUpgrade> UpgradeList)
    {
        GameObject[] newUpgrade = GameObject.FindGameObjectsWithTag("Upgrade");
        int i = 0;
        foreach (ShopUpgrade upg in UpgradeList)
        {
            TextMeshProUGUI[] text = newUpgrade[i].GetComponentsInChildren<TextMeshProUGUI>();
            text[0].SetText(upg.GetName());
            text[1].SetText(upg.GetDescription());
            text[3].SetText($"{upg.GetCost()}");
            text[5].SetText($"{upg.GetLevel()}");
            Button button = newUpgrade[i++].GetComponentInChildren<Button>();
            button.name = upg.GetName();
            if (upg.IsSoldOut())
            {
                button.enabled = false;
                button.GetComponent<Image>().color = button.colors.disabledColor;
                Destroy(text[2]);
                Destroy(text[3]);
            }
        }
    }

    public void UpdateUpgrade(ShopUpgrade upg, int index)
    {
        money.SetText($"{RocketStartingProfile.Instance.money}");
        GameObject newUpgrade = GameObject.FindGameObjectsWithTag("Upgrade")[index];
        TextMeshProUGUI[] text = newUpgrade.GetComponentsInChildren<TextMeshProUGUI>();
        text[3].SetText($"{upg.GetCost()}");
        text[5].SetText($"{upg.GetLevel()}");
        Button button = newUpgrade.GetComponentInChildren<Button>();
        if (upg.IsSoldOut())
        {
            button.enabled = false;
            button.GetComponent<Image>().color = button.colors.disabledColor;
            Destroy(text[2]);
            Destroy(text[3]);
        }
    }


    public void BuyUpgrade(Button Upgrade)
    {
        Image but = Upgrade.GetComponent<Image>();
        ShopUpgrade upg;
        Color temp = but.color;
        Color want = new Color(240f/255, 65f/255, 35f/255);
        string upgName = Upgrade.name;
        switch (upgName)
        {
            case "Armor":
                upg = UpgradeList.ElementAt(0);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.healthValue += (int)upg.GetValue();
                    upg.UpgradeBought();
                    UpdateUpgrade(upg,0);
                }
                else
                    StartCoroutine(ErrorButtonColor(but,want,temp));
                    break;
            case "Engine":
                upg = UpgradeList.ElementAt(1);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.engineValue = (int)upg.GetValue();
                    upg.UpgradeBought();
                    UpdateUpgrade(upg, 1);
                }
                else
                    StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
            case "Flaps":
                upg = UpgradeList.ElementAt(2);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.flapValue = (int)upg.GetValue();
                    upg.UpgradeBought();
                    UpdateUpgrade(upg, 2);
                }
                else
                    StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
            case "Head":
                upg = UpgradeList.ElementAt(3);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.headValue = (int)upg.GetValue();
                    upg.UpgradeBought();
                    UpdateUpgrade(upg, 3);
                }
                else
                    StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
            case "Fuel Storage":
                upg = UpgradeList.ElementAt(4);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.fuelValue += (int)upg.GetValue();
                    upg.UpgradeBought();
                    UpdateUpgrade(upg, 4);
                }
                else
                    StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
            case "Rocket Engineer":
                upg = UpgradeList.ElementAt(5);
                if (upg.GetCost() <= RocketStartingProfile.Instance.money){
                    RocketStartingProfile.Instance.money -= upg.GetCost();
                    RocketStartingProfile.Instance.hasEngineer = true;
                    upg.UpgradeBought();
                    UpdateUpgrade(upg, 5);
                }
                else
                    StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
            default:
                StartCoroutine(ErrorButtonColor(but, want, temp));
                break;
        }
        SaveUpgradesToProfile();
    }

    private IEnumerator ErrorButtonColor(Image button, Color col, Color normal)
    {
        button.color = col;
        yield return new WaitForSeconds(1);
        button.color = normal;
    }
    public void Close()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SaveUpgradesToProfile()
    {
        List<int> UpgradeLevels = new();
        foreach (ShopUpgrade upg in UpgradeList)
        {
            UpgradeLevels.Add(upg.GetLevel());
        }
        RocketStartingProfile.Instance.UpgradeLevels = UpgradeLevels;
    }
}