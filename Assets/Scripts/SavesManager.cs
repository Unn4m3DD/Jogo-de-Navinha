using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SavesManager
{
    public static void SaveGame(UpgradesHandler uH)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(Application.persistentDataPath + "/saveFile.svg", FileMode.Create);
        GameData data = new GameData(uH);
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static GameData LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/saveFile.svg"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Application.persistentDataPath + "/saveFile.svg", FileMode.Open);

            GameData data = (GameData)bf.Deserialize(fs);
            fs.Close();
            return (data);
        }
        Debug.LogError("SaveFile Does not Exist");
        return null;
    }
}

[Serializable]
public class GameData
{
    public GameData(UpgradesHandler uH)
    {
        SkillUpgrades = UpgradesHandler.SkillUpgrades;
        StatusUpgrades = UpgradesHandler.StatusUpgrades;
        CurrentSShip = UpgradesHandler.CurrentSShip;
        OwnedSShip = UpgradesHandler.OwnedSShip;
        Coins = UpgradesHandler.coin;
        selectedLevel = UpgradesHandler.selectedLevel;
        UnlockedLevels = UpgradesHandler.UnlockedLevels;
        rewardClaimed = UpgradesHandler.rewardClaimed;
        bossRewardClaimed = UpgradesHandler.bossRewardClaimed;
    }
    public int[] SkillUpgrades;
    //SlowMotionLVL;
    //DmgBoostLVL;
    //FiringRateBoostLVL;
    //MagnetLVL;
    //EmpLVL;

    public int[] StatusUpgrades;
    //PlayerHpLVL;
    //PlayerManaLVL;
    //PlayerDamageLVL;
    //PlayerCriticalChance;
    //PlayerFiringRateLVL;
    //PlayerUltimateLVL;
    //CoinBaseValue
    //Status:

    public int Coins;
    public bool[,] CurrentSShip;
    public bool[,] OwnedSShip;
    public int selectedLevel;
    public bool[] UnlockedLevels;
    public bool[] rewardClaimed;
    public bool[] bossRewardClaimed;
}
