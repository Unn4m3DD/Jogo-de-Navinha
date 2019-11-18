using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class UpgradesHandler : MonoBehaviour
{
    public GameObject[] Nave;




    //String[] TextoSkill = { "Slow Motion: this skill will reduce the velocity time passes, it gives you more time to think about you're next move.",
    //                      "Damage Boost: this skill will give you're damage a multiplier during 5 seconds, it allows you to kill them easly.",
    //                      "Firing Rate Boost: this skill will raise the amount of shot per time unit, more shots more damage, more fun!",
    //                      "Magnet: this skill will pull all the enemys into the center of the screen, you can combo it with you're ultimate shot."};

    public static int[] RecompensaLvl = { 0, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000,
                                             2000, 2100, 2200, 2300, 2400, 2500, 2600, 2700, 2800, 2900, 3000 };
    public static int[] RecompensaBoss = { 0, 19000, 45000, 90000, 190000, 400000, 900000, 1300000, 4000000, 9000000 };

    public GameObject Player;
    public GameObject MenuHandler;
    public GameObject coinDisplay;
    public static int[] StatusUpgrades;
    public static int[] SkillUpgrades;
    public static int coin;
    public int LvlNave;

    public static int selectedLevel;

    public static bool[,] CurrentSShip;
    public static bool[,] OwnedSShip;
    public static bool[] UnlockedLevels;
    public static bool[] rewardClaimed;
    public static bool[] bossRewardClaimed;
    int SaveTimer;

    public bool isInGame;
    GameObject[] CurrentSkillUpgLvlPrice, CurrentSkillUpgLvl, CurrentStatusUpgLvlPrice, CurrentStatusUpgLvl;

    public static bool[] BuyableSkill;

    public GameObject[] Naves;

    public void Start()
    {
        CurrentSkillUpgLvlPrice = new GameObject[4];
        CurrentSkillUpgLvl = new GameObject[4];
        CurrentStatusUpgLvlPrice = new GameObject[7];
        CurrentStatusUpgLvl = new GameObject[7];
        if (isInGame)
        {
            MenuHandler = GameObject.Find("aMenus");
        }
        else
        {

        }
        Load();

    }





    public void UpgSkillMenu()
    {
        UpdateCoinDisplay();
        for (int i = 0; i < CurrentSkillUpgLvl.Length; i++)
        {
            CurrentSkillUpgLvl[i] = GameObject.Find("CurrentSkillUpg" + i + "Lvl");
            CurrentSkillUpgLvlPrice[i] = GameObject.Find("CurrentSkillUpg" + i + "LvlPrice");
        }
        for (int i = 0; i < CurrentSkillUpgLvl.Length; i++)
        {
            if (10 > SkillUpgrades[i])
            {
                CurrentSkillUpgLvlPrice[i].GetComponent<Text>().text = "" + Upgrades.Preço[SkillUpgrades[i]];
                CurrentSkillUpgLvl[i].GetComponent<Text>().text = "" + SkillUpgrades[i];
            }
            else
            {
                //Cuidado Erro
                if (CurrentSkillUpgLvl[i] != null)
                    CurrentSkillUpgLvlPrice[i].SetActive(false);
            }
        }


    }
    public void UpgStatusMenu()
    {
        UpdateCoinDisplay();
        for (int i = 0; i < CurrentStatusUpgLvl.Length; i++)
        {
            CurrentStatusUpgLvl[i] = GameObject.Find("CurrentStatusUpg" + i + "Lvl");
            CurrentStatusUpgLvlPrice[i] = GameObject.Find("CurrentStatusUpg" + i + "LvlPrice");
        }
        for (int i = 0; i < CurrentStatusUpgLvl.Length; i++)
        {
            if (10 > StatusUpgrades[i])
            {
                CurrentStatusUpgLvlPrice[i].GetComponent<Text>().text = "" + Upgrades.Preço[StatusUpgrades[i]];
                CurrentStatusUpgLvl[i].GetComponent<Text>().text = "" + StatusUpgrades[i];
            }
            else
            {
                //Cuidado Erro
                if (CurrentStatusUpgLvl[i] != null)
                    CurrentStatusUpgLvlPrice[i].SetActive(false);
            }
        }

    }
    private void FixedUpdate()
    {
        if (SaveTimer > 5 / Time.deltaTime)
        {
            Save();
            SaveTimer = 0;
        }

        SaveTimer++;
    }

    public void UpgradeSkill(int SkillType)
    {
        if (SkillUpgrades[SkillType] < 10)
        {
            if (coin >= Upgrades.Preço[SkillUpgrades[SkillType]])
            {
                coin -= Upgrades.Preço[SkillUpgrades[SkillType]];
                SkillUpgrades[SkillType] += 1;
                CurrentSkillUpgLvl[SkillType].GetComponent<Text>().text = "" + SkillUpgrades[SkillType];
                if (SkillUpgrades[SkillType] < 10)
                    CurrentSkillUpgLvlPrice[SkillType].GetComponent<Text>().text = "" + Upgrades.Preço[SkillUpgrades[SkillType]];
                else
                {
                    CurrentSkillUpgLvlPrice[SkillType].SetActive(false);
                    GameObject.Find("Upgrade" + SkillType + "+").SetActive(false);
                }
                UpdateCoinDisplay();
            }
        }
    }
    public void UpgradeStatus(int StatusType)
    {
        if (StatusUpgrades[StatusType] < 10)
        {
            if (coin >= Upgrades.Preço[StatusUpgrades[StatusType]])
            {
                coin -= Upgrades.Preço[StatusUpgrades[StatusType]];
                StatusUpgrades[StatusType] += 1;
                CurrentStatusUpgLvl[StatusType].GetComponent<Text>().text = "" + StatusUpgrades[StatusType];
                if (StatusUpgrades[StatusType] < 10)
                    CurrentStatusUpgLvlPrice[StatusType].GetComponent<Text>().text = "" + Upgrades.Preço[StatusUpgrades[StatusType]];
                else
                {
                    CurrentStatusUpgLvlPrice[StatusType].SetActive(false);
                    GameObject.Find("Upgrade" + StatusType + "+").SetActive(false);
                }
                UpdateCoinDisplay();
            }
        }
    }
    public void CoinAdd()
    {
        coin += Upgrades.BaseCoinValue[StatusUpgrades[6]]; //6: Referencia ao slot onde é guardado o lvl da moeda
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        coinDisplay = GameObject.Find("CoinDisplay");
        coinDisplay.GetComponent<Text>().text = coin + " X ";

    }

    public void Save()
    {
        SavesManager.SaveGame(this);
    }
    public void Load()
    {
        //File.Delete(Application.persistentDataPath + "/saveFile.svg");
        GameData data = SavesManager.LoadGame();
        if (data == null)
        {
            ResetGame();
        }
        else
        {
            SkillUpgrades = data.SkillUpgrades;
            StatusUpgrades = data.StatusUpgrades;
            coin = data.Coins;
            CurrentSShip = data.CurrentSShip;
            OwnedSShip = data.OwnedSShip;
            selectedLevel = data.selectedLevel;
            UnlockedLevels = data.UnlockedLevels;
            rewardClaimed = data.rewardClaimed;

        }
        if (isInGame)
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (CurrentSShip[i, j])
                    {
                        if (i == 9)
                        {
                            Player = Instantiate(Naves[8 + j]);
                        }
                        else
                        {
                            Player = Instantiate(Naves[i]); ;
                        }
                        //Status Upgrades
                        Player1.hp = Upgrades.BaseHp[StatusUpgrades[0]] + ShipUpgrades.Hp[i];
                        Player1.maxHp = Upgrades.BaseHp[StatusUpgrades[0]] + ShipUpgrades.Hp[i];
                        Player1.maxMana = Upgrades.BaseMana[StatusUpgrades[1]] + ShipUpgrades.Mana[i];
                        Player1.mana = Upgrades.BaseMana[StatusUpgrades[1]] + ShipUpgrades.Mana[i];
                        Player.GetComponent<Player1>().BaseDmg = Upgrades.BaseDmg[StatusUpgrades[2]] + ShipUpgrades.Damage[i];
                        Player.GetComponent<Player1>().CriticalChance = Upgrades.CriticalChance[StatusUpgrades[3]] + ShipUpgrades.CriticalChance[i];
                        Player.GetComponent<Player1>().firingRate = Upgrades.FiringRate[StatusUpgrades[4]] + ShipUpgrades.FireRate[i];
                        Player.GetComponent<Transform>().position = new Vector3(0, -0.85f, 0);
                        Player.GetComponent<Player1>().pathNave = j;

                        break;
                    }
                }
            }
            //SkillUpgrades
            MenuHandler.GetComponent<MenuHandlerScript>().SlowMotionMaxTime = Upgrades.SlowMotionDuration[SkillUpgrades[0]];
            MenuHandler.GetComponent<MenuHandlerScript>().DmgMultiplier = Upgrades.DmgAndFiringRateMultiplier[SkillUpgrades[1]];
            MenuHandler.GetComponent<MenuHandlerScript>().firingRateMultiplier = Upgrades.DmgAndFiringRateMultiplier[SkillUpgrades[2]];
            MenuHandler.GetComponent<MenuHandlerScript>().MagnetMaxTime = Upgrades.MagnetAndEMPDurationAndCoinMultiplier[SkillUpgrades[3]];

            //StatusUpgrades

            //Path nave 



            UpdateCoinDisplay();
        }
        else
        {
        }


    }

    public void ResetGame()
    {
        SkillUpgrades = new int[6];
        StatusUpgrades = new int[7];
        OwnedSShip = new bool[10, 4];
        CurrentSShip = new bool[10, 4];
        CurrentSShip[1, 1] = true;
        OwnedSShip[1, 1] = OwnedSShip[1, 2] = OwnedSShip[1, 3] = true;
        UnlockedLevels = new bool[101];
        UnlockedLevels[1] = true;
        rewardClaimed = new bool[101];
        StatusUpgrades[6] = 1;
        coin = 0;
        bossRewardClaimed = new bool[11];
        Save();
    }
    public void ResetGameDebug()
    {
        SkillUpgrades = new int[6];
        StatusUpgrades = new int[7];
        OwnedSShip = new bool[10, 4];
        CurrentSShip = new bool[10, 4];
        CurrentSShip[1, 1] = true;
        OwnedSShip[1, 1] = OwnedSShip[1, 2] = OwnedSShip[1, 3] = true;
        UnlockedLevels = new bool[101];
        UnlockedLevels[1] = UnlockedLevels[10] = UnlockedLevels[20] = UnlockedLevels[30] = UnlockedLevels[40] = UnlockedLevels[50] = UnlockedLevels[60] = UnlockedLevels[70] = UnlockedLevels[80] = UnlockedLevels[90] = UnlockedLevels[100] = true;
        rewardClaimed = new bool[101];
        StatusUpgrades[6] = 1;
        coin = 1000000000;
        bossRewardClaimed = new bool[11];
        Save();
    }
    private void OnApplicationQuit()
    {
        Save();
    }


}
