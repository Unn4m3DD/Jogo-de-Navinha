using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject SShipUpgradeMenu;
    public GameObject SoundMenu;
    public GameObject UpgradesMenu;
    public GameObject UpgradeSkillsMenu, UpgradeStatusMenu, StatusPg1, StatusPg2, Dir, Esq;
    public GameObject Right, Left;
    public GameObject LevelSelect;
    public GameObject Traz, Frente;
    public GameObject SpaceShipPreview;

    public GameObject PathNameDisplay, PathDescription, ShipBaseAtributes;

    public GameObject BuyEquipBtnText;
    public GameObject CurrentCost;

    public Sprite[] NavePath1;
    public Sprite[] NavePath2;
    public Sprite[] NavePath3;
    public GameObject[] Locks;
    public GameObject[] Star;
    public static int currentPathSelected = 1;
    public static int SpaceShipLVLSelected = 1;

    public Sprite[] SkillStatusSprites;
    public GameObject SkillHelpName;
    public GameObject SkillHelpDesc;
    public GameObject SkillHelpImage;
    public GameObject SkillHelpCurrentAtributeUp;
    public GameObject SkillHelpCurrentAtributeDown;
    public GameObject SkillHelpNextAtributeUp;
    public GameObject SkillHelpNextAtributeDown;
    public GameObject DetailMenu;

    public GameObject[] UpgradeLock;

    public int currentPage = 1;

    private void Start()
    {
        LevelSelect.SetActive(false);
    }
    public void OpenScene1()
    {
        SceneManager.LoadScene("1st Level");
        Time.timeScale = 1f;

    }
    public void GoToMainMenu()
    {
        SShipUpgradeMenu.SetActive(false);

        UpgradesMenu.SetActive(false);
        UpgradeStatusMenu.SetActive(false);
        UpgradeSkillsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        LevelSelect.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void GoToSettingsMenu()
    {
        SShipUpgradeMenu.SetActive(false);
        LevelSelect.SetActive(false);

        UpgradesMenu.SetActive(false);
        UpgradeStatusMenu.SetActive(false);
        UpgradeSkillsMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void GoToSShipUpgradesMenu()
    {
        SpaceShipLVLSelected = 1;
        currentPathSelected = 1;
        Right.SetActive(true);
        Left.SetActive(false);
        SShipUpgradeMenu.SetActive(false);
        LevelSelect.SetActive(false);

        SShipUpgradeMenu.SetActive(true);
        UpgradesMenu.SetActive(false);
        UpgradeStatusMenu.SetActive(false);
        UpgradeSkillsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        UpdateCurrentSShipDisplay();
        if (UpgradesHandler.UnlockedLevels[15])
            UpgradeLock[1].SetActive(false);
        else
            UpgradeLock[1].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[25])
            UpgradeLock[2].SetActive(false);
        else
            UpgradeLock[2].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[30])
            UpgradeLock[3].SetActive(false);
        else
            UpgradeLock[3].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[45])
            UpgradeLock[4].SetActive(false);
        else
            UpgradeLock[4].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[50])
            UpgradeLock[5].SetActive(false);
        else
            UpgradeLock[5].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[60])
            UpgradeLock[6].SetActive(false);
        else
            UpgradeLock[6].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[65])
            UpgradeLock[7].SetActive(false);
        else
            UpgradeLock[7].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[75])
            UpgradeLock[8].SetActive(false);
        else
            UpgradeLock[8].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[80])
            UpgradeLock[9].SetActive(false);
        else
            UpgradeLock[9].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[90])
            UpgradeLock[10].SetActive(false);
        else
            UpgradeLock[10].SetActive(true);
        if (UpgradesHandler.UnlockedLevels[100])
            UpgradeLock[11].SetActive(false);
        else
            UpgradeLock[11].SetActive(true);
    }
    public void GotoUpgradeSkillsMenu()
    {
        LevelSelect.SetActive(false);

        UpgradesMenu.SetActive(true);
        UpgradeStatusMenu.SetActive(false);
        UpgradeSkillsMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        SShipUpgradeMenu.SetActive(false);

        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().UpgSkillMenu();
    }
    public void GotoUpgradeStatusMenu()
    {
        LevelSelect.SetActive(false);

        SShipUpgradeMenu.SetActive(false);

        UpgradesMenu.SetActive(true);
        UpgradeStatusMenu.SetActive(true);
        UpgradeSkillsMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        StatusPg1.SetActive(true);
        StatusPg2.SetActive(true);
        Dir.SetActive(true);
        Esq.SetActive(false);
        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().UpgStatusMenu();
        StatusPg1.SetActive(true);
        StatusPg2.SetActive(false);
        Dir.SetActive(true);
        Esq.SetActive(false);

    }
    public void GoToDir()
    {
        StatusPg1.SetActive(false);
        StatusPg2.SetActive(true);
        Dir.SetActive(false);
        Esq.SetActive(true);

    }
    public void GoToEsq()
    {
        StatusPg1.SetActive(true);
        StatusPg2.SetActive(false);
        Dir.SetActive(true);
        Esq.SetActive(false);

    }
    public void GoToRight()
    {
        SpaceShipLVLSelected++;
        if (SpaceShipLVLSelected == 9)
            Right.SetActive(false);
        if (SpaceShipLVLSelected != 1)
            Left.SetActive(true);
        UpdateCurrentSShipDisplay();
    }
    public void GoToLeft()
    {
        SpaceShipLVLSelected--;
        if (SpaceShipLVLSelected == 1)
            Left.SetActive(false);
        if (SpaceShipLVLSelected != 9)
            Right.SetActive(true);
        UpdateCurrentSShipDisplay();
    }
    public void GotoLevelSelector()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
        Traz.SetActive(false);
        currentPage = 1;
        for (int i = 0; i < 21; i++)
        {
            if (UpgradesHandler.UnlockedLevels[i])
                Locks[i].SetActive(false);
            if (UpgradesHandler.rewardClaimed[i])
                Star[i].SetActive(true);
            else
                Star[i].SetActive(false);
        }
    }
    public void BuyShip()
    {
        if (UpgradesHandler.OwnedSShip[SpaceShipLVLSelected, currentPathSelected])
        {
            UpgradesHandler.CurrentSShip = new bool[10, 4];
            UpgradesHandler.CurrentSShip[SpaceShipLVLSelected, currentPathSelected] = true;
        }
        else if (ShipUpgrades.Preco[SpaceShipLVLSelected] < UpgradesHandler.coin)
        {
            UpgradesHandler.coin -= ShipUpgrades.Preco[SpaceShipLVLSelected];
            UpgradesHandler.CurrentSShip = new bool[10, 4];
            UpgradesHandler.CurrentSShip[SpaceShipLVLSelected, currentPathSelected] = true;
            UpgradesHandler.OwnedSShip[SpaceShipLVLSelected, currentPathSelected] = true;
        }
        GameObject.Find("CoinDisplay").GetComponent<Text>().text = UpgradesHandler.coin + " X ";
        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().Save();
        UpdateCurrentSShipDisplay();
    }
    public void SelectPath(int path)
    {
        currentPathSelected = path;
        UpdateCurrentSShipDisplay();

    }
    public void UpdateCurrentSShipDisplay()
    {
        if (currentPathSelected == 1)
        {
            PathNameDisplay.GetComponent<Text>().text = "The Purple Path:";
            PathDescription.GetComponent<Text>().text = "This is the main path.\nBalanced in atack damage and hp.\nFor the basic ones.";
            SpaceShipPreview.GetComponent<Image>().sprite = NavePath1[SpaceShipLVLSelected];
        }
        if (currentPathSelected == 2)
        {
            PathNameDisplay.GetComponent<Text>().text = "The Blue Path:";
            PathDescription.GetComponent<Text>().text = "This is the chill path.\nStay still even after a bunch of pokes.\nFor the lazy ones.";
            SpaceShipPreview.GetComponent<Image>().sprite = NavePath2[SpaceShipLVLSelected];
        }
        if (currentPathSelected == 3)
        {
            PathNameDisplay.GetComponent<Text>().text = "The Red Path:";
            PathDescription.GetComponent<Text>().text = "This is the RAGE path.\nThe best defence is the attack right?.\nFor the brutal ones.";
            SpaceShipPreview.GetComponent<Image>().sprite = NavePath3[SpaceShipLVLSelected];
        }
        if ((UpgradesHandler.OwnedSShip[SpaceShipLVLSelected, currentPathSelected] && UpgradesHandler.CurrentSShip[SpaceShipLVLSelected, currentPathSelected]) || (SpaceShipLVLSelected == 1 && (UpgradesHandler.CurrentSShip[1, 1] || UpgradesHandler.CurrentSShip[1, 3] || UpgradesHandler.CurrentSShip[1, 2])))
        {
            BuyEquipBtnText.GetComponent<Text>().text = "Equiped";
            CurrentCost.SetActive(false);
        }
        else if (UpgradesHandler.OwnedSShip[SpaceShipLVLSelected, currentPathSelected])
        {
            BuyEquipBtnText.GetComponent<Text>().text = "Equip";
            CurrentCost.SetActive(false);
        }
        else
        {
            CurrentCost.SetActive(true);
            BuyEquipBtnText.GetComponent<Text>().text = "Buy";
            CurrentCost.GetComponent<Text>().text = "" + ShipUpgrades.Preco[SpaceShipLVLSelected] + " X ";
        }
        ShipBaseAtributes.GetComponent<Text>().text = "LEVEL: " + SpaceShipLVLSelected +
                                                    "\nHP: " + ShipUpgrades.Hp[SpaceShipLVLSelected] +
                                                    "\nMANA:" + ShipUpgrades.Mana[SpaceShipLVLSelected] +
                                                    "\nFIRE RATE:" + ShipUpgrades.FireRate[SpaceShipLVLSelected] +
                                                    "\nDAMAGE: " + ShipUpgrades.Damage[SpaceShipLVLSelected] +
                                                    "\nCRITICAL CHANCE: " + ShipUpgrades.CriticalChance[SpaceShipLVLSelected] + " % ";
        GameObject.Find("CoinDisplay").GetComponent<Text>().text = UpgradesHandler.coin + " X ";
    }

    public void GotoFrente()
    {
        currentPage++;
        GameObject[] lvl = new GameObject[22];
        for (int i = 1; i < 21; i++)
        {
            lvl[i] = GameObject.Find("Lvl" + i);
        }
        int j = 1;
        for (int i = 20 * currentPage - 19; i < 20 * currentPage + 1; i++)
        {
            lvl[j].GetComponentInChildren<Text>().text = "" + (i);
            if (UpgradesHandler.UnlockedLevels[i])
                Locks[j].SetActive(false);
            else
                Locks[j].SetActive(true);

            if (UpgradesHandler.rewardClaimed[i])
                Star[j].SetActive(true);
            else
                Star[j].SetActive(false);
            j++;
        }
        if (currentPage == 5)
        {
            Frente.SetActive(false);
        }
        if (currentPage == 2)
        {
            Traz.SetActive(true);
        }
    }
    public void GotoTraz()
    {
        currentPage--;
        GameObject[] lvl = new GameObject[22];
        for (int i = 1; i < 21; i++)
        {
            lvl[i] = GameObject.Find("Lvl" + i);
        }
        int j = 1;
        for (int i = 20 * currentPage - 19; i < 20 * currentPage + 1; i++)
        {
            lvl[j].GetComponentInChildren<Text>().text = "" + (i);
            if (UpgradesHandler.UnlockedLevels[i])
                Locks[j].SetActive(false);
            else
                Locks[j].SetActive(true);

            if (UpgradesHandler.rewardClaimed[i])
                Star[j].SetActive(true);
            else
                Star[j].SetActive(false);
            j++;
        }

        if (currentPage == 4)
        {
            Frente.SetActive(true);
        }
        if (currentPage == 1)
        {
            Traz.SetActive(false);
        }
    }

    public void ExitDetailMenu()
    {
        DetailMenu.SetActive(false);
    }

    public void ShowSkillStatusDeatil(int type)
    {
        DetailMenu.SetActive(true);
        SkillHelpName.GetComponent<Text>().text = UpgradesDesc.name[type];
        SkillHelpDesc.GetComponent<Text>().text = UpgradesDesc.desc[type];
        SkillHelpImage.GetComponent<Image>().sprite = SkillStatusSprites[type];
        SkillHelpCurrentAtributeUp.GetComponent<Text>().text = UpgradesDesc.attribute[type];
        SkillHelpNextAtributeUp.GetComponent<Text>().text = UpgradesDesc.attribute[type];

        try
        {

            if (type == 0)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.SlowMotionDuration[UpgradesHandler.SkillUpgrades[0]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.SlowMotionDuration[UpgradesHandler.SkillUpgrades[0] + 1] + UpgradesDesc.attributeUnit[type];

            }
            else if (type == 1)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.DmgAndFiringRateMultiplier[UpgradesHandler.SkillUpgrades[1]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.DmgAndFiringRateMultiplier[UpgradesHandler.SkillUpgrades[1] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 2)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.DmgAndFiringRateMultiplier[UpgradesHandler.SkillUpgrades[2]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.DmgAndFiringRateMultiplier[UpgradesHandler.SkillUpgrades[2] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 3)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.MagnetAndEMPDurationAndCoinMultiplier[UpgradesHandler.SkillUpgrades[3]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.MagnetAndEMPDurationAndCoinMultiplier[UpgradesHandler.SkillUpgrades[3] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 4)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.BaseHp[UpgradesHandler.StatusUpgrades[0]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.BaseHp[UpgradesHandler.StatusUpgrades[0] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 5)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.BaseMana[UpgradesHandler.StatusUpgrades[1]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.BaseMana[UpgradesHandler.StatusUpgrades[1] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 6)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.BaseDmg[UpgradesHandler.StatusUpgrades[2]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.BaseDmg[UpgradesHandler.StatusUpgrades[2] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 7)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.CriticalChance[UpgradesHandler.StatusUpgrades[3]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.CriticalChance[UpgradesHandler.StatusUpgrades[3] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 8)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.FiringRate[UpgradesHandler.StatusUpgrades[4]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.FiringRate[UpgradesHandler.StatusUpgrades[4] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 9)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.BaseUltDmg[UpgradesHandler.StatusUpgrades[5]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.BaseUltDmg[UpgradesHandler.StatusUpgrades[5] + 1] + UpgradesDesc.attributeUnit[type];
            }
            else if (type == 10)
            {
                SkillHelpCurrentAtributeDown.GetComponent<Text>().text = Upgrades.BaseCoinValue[UpgradesHandler.StatusUpgrades[6]] + UpgradesDesc.attributeUnit[type];
                SkillHelpNextAtributeDown.GetComponent<Text>().text = Upgrades.BaseCoinValue[UpgradesHandler.StatusUpgrades[6] + 1] + UpgradesDesc.attributeUnit[type];
            }
        }
        catch (System.Exception)
        {
            if (UpgradesHandler.SkillUpgrades[0] == 10)
                SkillHelpNextAtributeDown.GetComponent<Text>().text = "MAX LEVEL";
        }

    }
    public void SelectLevel(int Lvl)
    {
        if (UpgradesHandler.UnlockedLevels[Lvl + 20 * currentPage - 20])
        {
            UpgradesHandler.selectedLevel = Lvl + 20 * currentPage - 20;
            GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().Save();
            SceneManager.LoadScene("1st Level");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
