using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandlerScript : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject[] SkillSlot;

    public GameObject Nave;

    float DmgBoostTimer;

    public float DmgBoostMaxTime;

    public float DmgMultiplier;

    float SlowMotionTimer;

    public float SlowMotionMaxTime;

    public float firingRateMultiplier;

    public float MagnetTimer;

    public float MagnetMaxTime;

    public static bool isMagnetActive;

    private void Start()
    {


    }
    private void Update()
    {
        if (Nave == null)
            Nave = GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().Player;

    }
    void FixedUpdate()
    {
        if (Player1.hp >= 0)
        {
            //SlowMotionTimer
            if (SlowMotionTimer >= SlowMotionMaxTime / Time.deltaTime && Time.timeScale > 0 && Time.timeScale < 1)
            {
                Time.timeScale = 1;
                SlowMotionTimer = 0;
            }
            else if (Time.timeScale > 0 && Time.timeScale < 1)
                SlowMotionTimer++;
            try
            {//DmgBoostTimer
                if (DmgBoostTimer >= DmgBoostMaxTime / Time.deltaTime && Nave.GetComponent<Player1>().dmgMultiplier != 1f)
                {
                    Nave.GetComponent<Player1>().dmgMultiplier = 1f;
                    DmgBoostTimer = 0;
                }
                else if (Nave.GetComponent<Player1>().dmgMultiplier != 1f)
                    DmgBoostTimer++;
                //MagnetTimer
                if (MagnetTimer >= MagnetMaxTime / Time.deltaTime && isMagnetActive)
                {
                    Magnet(false);
                    MagnetTimer = 0;
                }
                else if (Nave.GetComponent<Player1>().dmgMultiplier != 1f)
                    MagnetTimer++;

            }
            catch (UnassignedReferenceException)
            {
            }

        }
    }


    public GameObject pauseMenu;
    public GameObject inGameMenu;






    public void TurnSkillSlotOff(int skillSlotNumber)
    {
        UseSkill(Nave.GetComponent<Player1>().skillStored[skillSlotNumber]);
        SkillSlot[skillSlotNumber].SetActive(false);
        Nave.GetComponent<Player1>().DeleteUsedSkill(skillSlotNumber);
    }

    private void UseSkill(int skillType)
    {
        if (skillType == 1)
            SlowMotion();
        if (skillType == 2)
            BonusDmg();
        if (skillType == 3)
            FiringRateMultiplier();
        if (skillType == 4)
            Magnet(true);
    }

    private void BonusDmg()
    {
        Nave.GetComponent<Player1>().dmgMultiplier = DmgMultiplier;
    }

    public void SlowMotion()
    {
        Time.timeScale = .5f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        inGameMenu.SetActive(false);
        isPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        inGameMenu.SetActive(true);
        isPaused = false;

    }
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void FiringRateMultiplier()
    {
        Nave.GetComponent<Player1>().firingRate *= firingRateMultiplier;
    }
    public void Magnet(bool SetActive)
    {
        isMagnetActive = SetActive;
    }
    public void NextLevel()
    {
        UpgradesHandler.selectedLevel += 1;
        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Player1.hpFreeze = false;
    }
}
