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
        fuelValue = 100;
        passiveRepairValue = 0;
        hasEngineer = false;
        hasDetector = false;
        rocketColor = Color.red;
    }

    public static RocketStartingProfile GetInstance()
    {
        if (instance == null)
            instance = new RocketStartingProfile();
        return instance;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        RocketStartingProfile a = GetInstance();
    }

}
