using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Upgrades
{

    public static int[] Preço = { 1000, 1500, 2500, 5000, 10000, 15000, 25000, 50000, 75000, 100000 };

    public static int[] SlowMotionDuration = { 0, 2, 3, 5, 6, 7, 8, 10, 12, 15, 20 };

    public static float[] DmgAndFiringRateMultiplier = { 0, 1.1f, 1.2f, 1.3f, 1.5f, 1.7f, 2.0f, 2.3f, 2.5f, 2.7f, 3.0f };

    public static float[] MagnetAndEMPDurationAndCoinMultiplier = { 0, 1.0f, 1.1f, 1.2f, 1.5f, 1.7f, 1.8f, 2.0f, 2.4f, 2.8f, 3.0f };

    public static int[] BaseDmg = { 0, 10, 12, 15, 25, 35, 50, 75, 100, 125, 150 };

    public static int[] BaseHp = { 0, 10, 12, 15, 25, 35, 50, 75, 100, 125, 150 };

    public static int[] BaseUltDmg = { 0, 10, 12, 15, 25, 35, 50, 75, 100, 125, 150 };

    public static int[] CriticalChance = { 0, 1, 2, 3, 5, 7, 9, 10, 12, 13, 15 };

    public static float[] FiringRate = { 0, 0.02f, 0.006f, 0.01f, 0.016f, 0.020f, 0.024f, 0.030f, 0.034f, 0.40f, 0.06f };

    public static int[] BaseMana = { 0, 100, 120, 140, 160, 200, 250, 300, 350, 400, 500 };

    public static int[] BaseCoinValue = { 0, 10, 11, 12, 15, 17, 18, 20, 24, 28, 30 };

}
public static class ShipUpgrades
{
    public static int[] Preco = { 0, 0, 20000, 50000, 100000, 200000, 500000, 1000000, 1500000, 5000000, 10000000 };

    public static int[] Hp = { 0, 100, 125, 200, 250, 300, 500, 750, 1000, 1500, 2000 };

    public static int[] Mana = { 0, 0, 0, 0, 0, 100, 125, 200, 250, 300, 500, 10000 };

    public static float[] FireRate = { 0, 0.16f, 0.164f, 0.168f, 0.172f, 0.176f, 0.18f, 0.184f, 0.190f, 0.2f, 0.2f };

    public static int[] Canons = { 0, 2, 4, 6, 6, 8, 10, 12, 14, 16, 18 };

    public static int[] Damage = { 0, 100, 110, 120, 130, 140, 150, 160, 170, 180, 200 };

    public static int[] CriticalChance = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


}

public static class UpgradesDesc
{
    public static string[] name =
    {
        "SLOW MOTION",
        "DAMAGE BOOST",
        "FIRE RATE BOOST",
        "MAGNET",
        "HEALTH",
        "MANA",
        "BASE DAMAGE",
        "CRITICAL CHANCE" ,
        "FIRE RATE",
        "ULTIMATE DAMAGE",
        "COIN VALUE"
    };
    public static string[] desc =
    {
         "THIS SKILL WILL SLOW\nDOWN THE TIME",
         "THIS SKILL WILL APPLY\nA DAMAGE MULTIPLIER",
         "THIS SKILL WILL APPLY\nA FIRE RATE MULTIPLIER",
         "THIS SKILL WILL ATRACT\nTHE ENEMYS TO THE CENTER",
         "THIS UPGRADE INCREASES\n BASE HP",
         "THIS UPGRADE INCREASES\n BASE MANA",
         "THIS UPGRADE INCREASES\n BASE DAMAGE",
         "THIS UPGRADE INCREASES\n BASE CRITICAL CHANCE",
         "THIS UPGRADE INCREASES\n BASE FIRE RATE",
         "THIS UPGRADE INCREASES\n BASE ULTIMATE DAMAGE",
         "THIS UPGRADE INCREASES\n BASE COIN VALUE",

    };
    public static string[] attribute =
    {
        "DURATION",
        "MULTIPLIER",
        "MULTIPLIER",
        "DURATION",
        "HP",
        "MANA",
        "DMG",
        "CHANCE",
        "MULTIPLIER",
        "DMG",
        "VALUE"
    };
    public static string[] attributeUnit =
    {
        "SEC",
        "X",
        "X",
        "SEC",
        "HP",
        "MANA",
        "DMG",
        "%",
        "X",
        "DMG",
        "COINS"
    };
}
//SlowMotionLVL;
//DmgBoostLVL;
//FiringRateBoostLVL;
//MagnetLVL;
//EmpLVL;

//PlayerHpLVL;
//PlayerManaLVL;
//PlayerDamageLVL;
//PlayerCriticalChance;
//PlayerFiringRateLVL;
//PlayerUltimateLVL;
//CoinBaseValue
//Status: