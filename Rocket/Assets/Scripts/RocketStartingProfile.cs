using System;
using UnityEngine;

public class RocketStartingProfile
{
    private static RocketStartingProfile instance;

    public string playerName { get; set; }
    public int money { get; set; }
    public int healthValue { get; set; }
    public float engineValue { get; set; }
    public float flapValue { get; set; }
    public int headValue { get; set; }
    public int fuelValue { get; set; }
    public int passiveRepairValue { get; set; }
    public bool hasEngineer { get; set; }
    public bool hasDetector { get; set; }
    public Color rocketColor { get; set; }

    private RocketStartingProfile()
    {
        playerName = "Spacey";
        money = 0;
        healthValue = 100;
        engineValue = 1;
        flapValue = 1;
        headValue = 5;
        fuelValue = 100;
        passiveRepairValue = 3;
        hasEngineer = false;
        hasDetector = false;
        rocketColor = Color.red;
    }

    public static RocketStartingProfile GetInstance()
    {
        if (instance == null)
        { 
            instance = new RocketStartingProfile();
        }
        return instance;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        RocketStartingProfile a = GetInstance();
    }

    public void Save(ref ProfileData data)
    {
        data.playerName = playerName;
        data.money = money;
        data.healthValue = healthValue;
        data.engineValue = engineValue;
        data.flapValue = flapValue;
        data.headValue = headValue;
        data.fuelValue = fuelValue;
        data.passiveRepairValue = passiveRepairValue;
        data.hasEngineer = hasEngineer;
        data.hasDetector = hasDetector;
        data.rocketColor = rocketColor;
    }

    public void Load(ProfileData data)
    {
        GetInstance();
        playerName = data.playerName;
        money = data.money;
        healthValue = data.healthValue;
        engineValue = data.engineValue;
        flapValue = data.flapValue;
        headValue = data.headValue;
        fuelValue = data.fuelValue;
        passiveRepairValue = data.passiveRepairValue;
        hasEngineer = data.hasEngineer;
        hasDetector = data.hasDetector;
        rocketColor = data.rocketColor;
    }

}

[System.Serializable]
public struct ProfileData
{
    public string playerName;
    public int money;
    public int healthValue;
    public float engineValue;
    public float flapValue;
    public int headValue;
    public int fuelValue;
    public int passiveRepairValue;
    public bool hasEngineer;
    public bool hasDetector;
    public Color rocketColor;
}