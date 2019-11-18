using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    public float Timer;
    float AfterKillLastEnemyTimer;

    public GameObject[] Inimigo;
    public GameObject[] Boss;

    public GameObject DeathScreen;

    public bool AllEnemysKilled;

    public bool EndCycleDone;
    [HideInInspector]
    public bool[] EnemySpawned1, EnemySpawned2, EnemySpawned3, EnemySpawned4, EnemySpawned5, EnemySpawned6, EnemySpawned7, EnemySpawned8, EnemySpawned9, EnemySpawned10;
    [HideInInspector]
    public bool[] EnemyToSpawn1, EnemyToSpawn2, EnemyToSpawn3, EnemyToSpawn4, EnemyToSpawn5, EnemyToSpawn6, EnemyToSpawn7, EnemyToSpawn8, EnemyToSpawn9, EnemyToSpawn10;

    public bool[] AllEnemyKilled;
    public bool[] BossKilled;

    public bool[] BossSpawned;
    // Use this for initialization
    void Start()
    {
        BossKilled = new bool[11];
        BossSpawned = new bool[11];
        AllEnemyKilled = new bool[11];
        #region Enemy1
        if (UpgradesHandler.selectedLevel == 1)
            EnemyToSpawn1 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 2)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 3)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 4)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 5)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 6)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 7)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 8)
            EnemyToSpawn1 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 9)
            EnemyToSpawn1 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 11)
            EnemyToSpawn1 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 12)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 13)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 14)
            EnemyToSpawn1 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 15)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 16)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 17)
            EnemyToSpawn1 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 18)
            EnemyToSpawn1 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 19)
            EnemyToSpawn1 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};

        EnemySpawned1 = new bool[75];
        #endregion

        #region Enemy2
        if (UpgradesHandler.selectedLevel == 11)
            EnemyToSpawn2 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 12)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 13)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 14)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 15)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 16)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 17)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 18)
            EnemyToSpawn2 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 19)
            EnemyToSpawn2 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 21)
            EnemyToSpawn2 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 22)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 23)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 24)
            EnemyToSpawn2 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 25)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 26)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 27)
            EnemyToSpawn2 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 28)
            EnemyToSpawn2 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 29)
            EnemyToSpawn2 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};


        EnemySpawned2 = new bool[75];
        #endregion

        #region Enemy3

        EnemySpawned3 = new bool[75];
        if (UpgradesHandler.selectedLevel == 21)
            EnemyToSpawn3 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 22)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 23)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 24)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 25)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 26)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 27)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 28)
            EnemyToSpawn3 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 29)
            EnemyToSpawn3 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};

        if (UpgradesHandler.selectedLevel == 31)
            EnemyToSpawn3 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 32)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 33)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 34)
            EnemyToSpawn3 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 35)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 36)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 37)
            EnemyToSpawn3 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 38)
            EnemyToSpawn3 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 39)
            EnemyToSpawn3 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};


        #endregion

        #region Enemy4

        EnemySpawned4 = new bool[75];
        if (UpgradesHandler.selectedLevel == 31)
            EnemyToSpawn4 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 32)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 33)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 34)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 35)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 36)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 37)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 38)
            EnemyToSpawn4 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 39)
            EnemyToSpawn4 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};

        if (UpgradesHandler.selectedLevel == 41)
            EnemyToSpawn4 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 42)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 43)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 44)
            EnemyToSpawn4 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 45)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 46)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 47)
            EnemyToSpawn4 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 48)
            EnemyToSpawn4 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 49)
            EnemyToSpawn4 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy5
        EnemySpawned5 = new bool[75];
        if (UpgradesHandler.selectedLevel == 41)
            EnemyToSpawn5 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 42)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 43)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 44)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 45)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 46)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 47)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 48)
            EnemyToSpawn5 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 49)
            EnemyToSpawn5 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 51)
            EnemyToSpawn5 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 52)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 53)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 54)
            EnemyToSpawn5 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 55)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 56)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 57)
            EnemyToSpawn5 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 58)
            EnemyToSpawn5 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 59)
            EnemyToSpawn5 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy6
        EnemySpawned6 = new bool[75];

        if (UpgradesHandler.selectedLevel == 51)
            EnemyToSpawn6 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 52)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 53)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 54)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 55)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 56)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 57)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 58)
            EnemyToSpawn6 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 59)
            EnemyToSpawn6 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 61)
            EnemyToSpawn6 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 62)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 63)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 64)
            EnemyToSpawn6 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 65)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 66)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 67)
            EnemyToSpawn6 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 68)
            EnemyToSpawn6 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 69)
            EnemyToSpawn6 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy7

        EnemySpawned7 = new bool[75];
        if (UpgradesHandler.selectedLevel == 61)
            EnemyToSpawn7 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 62)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 63)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 64)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 65)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 66)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 67)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 68)
            EnemyToSpawn7 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 69)
            EnemyToSpawn7 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 71)
            EnemyToSpawn7 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 72)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 73)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 74)
            EnemyToSpawn7 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 75)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 76)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 77)
            EnemyToSpawn7 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 78)
            EnemyToSpawn7 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 79)
            EnemyToSpawn7 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy8
        EnemySpawned8 = new bool[75];

        if (UpgradesHandler.selectedLevel == 71)
            EnemyToSpawn8 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 72)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 73)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 74)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 75)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 76)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 77)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 78)
            EnemyToSpawn8 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 79)
            EnemyToSpawn8 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 81)
            EnemyToSpawn8 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 82)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 83)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 84)
            EnemyToSpawn8 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 85)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 86)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 87)
            EnemyToSpawn8 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 88)
            EnemyToSpawn8 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 89)
            EnemyToSpawn8 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy9
        EnemySpawned9 = new bool[75];

        if (UpgradesHandler.selectedLevel == 81)
            EnemyToSpawn9 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 82)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 83)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 84)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 85)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 86)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 87)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 88)
            EnemyToSpawn9 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 89)
            EnemyToSpawn9 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 91)
            EnemyToSpawn9 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 92)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 93)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 94)
            EnemyToSpawn9 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 95)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 96)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 97)
            EnemyToSpawn9 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 98)
            EnemyToSpawn9 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 99)
            EnemyToSpawn9 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        #region Enemy10
        EnemySpawned9 = new bool[75];
        if (UpgradesHandler.selectedLevel == 91)
            EnemyToSpawn10 = new bool[] {true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,false,
                                        true,false,false,false,true,false,false,false,true,false,
                                        false,false,true,false,false,false,true,false,false,true};
        if (UpgradesHandler.selectedLevel == 92)
            EnemyToSpawn10 = new bool[] {true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false,
                                        true,false,false,true,false,false,false,true,false,false};
        if (UpgradesHandler.selectedLevel == 93)
            EnemyToSpawn10 = new bool[] {true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,
                                        true,false,false,true,false,false,true,false,false,true,
                                        false,false,true,false,false,true,false,false,true,false,
                                        false,true,false,false,true,false,false,true,false,false,};
        if (UpgradesHandler.selectedLevel == 94)
            EnemyToSpawn10 = new bool[] {true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false,
                                        true,false,false,true,false,true,false,false,true,false};
        if (UpgradesHandler.selectedLevel == 95)
            EnemyToSpawn10 = new bool[] {true,false,true,false,true,false,false,true,false,true,
                                        false,true,false,false,true,false,true,false,true,false,
                                        false,true,false,true,false,true,false,false,true,false,
                                        true,false,true,false,false,true,false,true,false,true,
                                        false,false,true,false,true,false,true,false,false,true,
                                        false,true,false,true,false,false,true,false,true,true};
        if (UpgradesHandler.selectedLevel == 96)
            EnemyToSpawn10 = new bool[] {true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false,
                                        true,false,true,false,true,false,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 97)
            EnemyToSpawn10 = new bool[] {true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 98)
            EnemyToSpawn10 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,false,true,false,true,true,true,false,true,false};
        if (UpgradesHandler.selectedLevel == 99)
            EnemyToSpawn10 = new bool[] {true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true,
                                        true,true,true,false,true,true,true,false,true,true};
        #endregion

        if (UpgradesHandler.selectedLevel < 10)
        {
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 10 && UpgradesHandler.selectedLevel < 20)
        {
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 20 && UpgradesHandler.selectedLevel < 30)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 30 && UpgradesHandler.selectedLevel < 40)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 40 && UpgradesHandler.selectedLevel < 50)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 50 && UpgradesHandler.selectedLevel < 60)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 60 && UpgradesHandler.selectedLevel < 70)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 70 && UpgradesHandler.selectedLevel < 80)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 80 && UpgradesHandler.selectedLevel < 90)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[10] = true;
        }
        else if (UpgradesHandler.selectedLevel > 90 && UpgradesHandler.selectedLevel < 100)
        {
            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
        }
        else if (UpgradesHandler.selectedLevel == 10 || UpgradesHandler.selectedLevel == 20 || UpgradesHandler.selectedLevel == 30 || UpgradesHandler.selectedLevel == 40 || UpgradesHandler.selectedLevel == 50 || UpgradesHandler.selectedLevel == 60 || UpgradesHandler.selectedLevel == 70 || UpgradesHandler.selectedLevel == 80 || UpgradesHandler.selectedLevel == 90 || UpgradesHandler.selectedLevel == 100)
        {

            AllEnemyKilled[1] = true;
            AllEnemyKilled[2] = true;
            AllEnemyKilled[3] = true;
            AllEnemyKilled[4] = true;
            AllEnemyKilled[5] = true;
            AllEnemyKilled[6] = true;
            AllEnemyKilled[7] = true;
            AllEnemyKilled[8] = true;
            AllEnemyKilled[9] = true;
            AllEnemyKilled[10] = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Timer += Time.deltaTime;
        for (int i = 1; i < 11; i++)
        {
            if (UpgradesHandler.selectedLevel == (i) * 10)
                SpawnBoss(i);
            else
                BossKilled[i] = true;

        }
        if (UpgradesHandler.selectedLevel < 10)
        {
            SpawnEnemy1();
        }
        #region Spawns

        else if (UpgradesHandler.selectedLevel > 10 && UpgradesHandler.selectedLevel < 20)
        {
            SpawnEnemy1();
            SpawnEnemy2();
        }
        else if (UpgradesHandler.selectedLevel > 20 && UpgradesHandler.selectedLevel < 30)
        {
            SpawnEnemy2();
            SpawnEnemy3();
        }
        else if (UpgradesHandler.selectedLevel > 30 && UpgradesHandler.selectedLevel < 40)
        {
            SpawnEnemy3();
            SpawnEnemy4();
        }
        else if (UpgradesHandler.selectedLevel > 40 && UpgradesHandler.selectedLevel < 50)
        {
            SpawnEnemy4();
            SpawnEnemy5();
        }
        else if (UpgradesHandler.selectedLevel > 50 && UpgradesHandler.selectedLevel < 60)
        {
            SpawnEnemy5();
            SpawnEnemy6();
        }
        else if (UpgradesHandler.selectedLevel > 60 && UpgradesHandler.selectedLevel < 70)
        {
            SpawnEnemy6();
            SpawnEnemy7();
        }
        else if (UpgradesHandler.selectedLevel > 70 && UpgradesHandler.selectedLevel < 80)
        {
            SpawnEnemy7();
            SpawnEnemy8();
        }
        else if (UpgradesHandler.selectedLevel > 80 && UpgradesHandler.selectedLevel < 90)
        {
            SpawnEnemy8();
            SpawnEnemy9();
        }
        else if (UpgradesHandler.selectedLevel > 90 && UpgradesHandler.selectedLevel < 100)
        {
            SpawnEnemy9();
            SpawnEnemy10();
        }
        #endregion


        AllEnemysKilled = AllEnemyKilled[1] && BossKilled[1] && AllEnemyKilled[2] && BossKilled[2]
                                          && AllEnemyKilled[3] && BossKilled[3] && AllEnemyKilled[4] && BossKilled[4]
                                          && AllEnemyKilled[5] && BossKilled[5] && AllEnemyKilled[6] && BossKilled[6]
                                          && AllEnemyKilled[7] && BossKilled[7] && AllEnemyKilled[8] && BossKilled[8]
                                          && AllEnemyKilled[9] && BossKilled[9] && AllEnemyKilled[9] && BossKilled[9]
                                          && AllEnemyKilled[10] && BossKilled[10];



        if (!EndCycleDone)
        {
            if (AllEnemysKilled)
            {
                AfterKillLastEnemyTimer += Time.deltaTime;
                if (AfterKillLastEnemyTimer > 3)
                {
                    Victory();
                    EndCycleDone = true;
                }
            }

            if (Player1.hp <= 0)
            {
                Defeat();
                EndCycleDone = true;
            }
        }

    }

    private void SpawnBoss(int bossNo)
    {
        if (!BossSpawned[bossNo])
        {
            GameObject BossX = Instantiate(Boss[bossNo]);
            BossX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
            BossSpawned[bossNo] = true;
        }
        if (GameObject.Find("Boss" + bossNo + "(Clone)") == null && !BossKilled[bossNo])
        {
            BossKilled[bossNo] = true;
        }
    }

    private void SpawnEnemy1()
    {
        if (EnemyToSpawn1.Length - 1 > Timer)
        {
            if (EnemyToSpawn1[Mathf.RoundToInt(Timer)] && !EnemySpawned1[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[1]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned1[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 1 + "(Clone)") == null && !AllEnemyKilled[1])
        {
            AllEnemyKilled[1] = true;
        }
        if (GameObject.Find("Inimigo" + 1 + "(Clone)") == null && UpgradesHandler.selectedLevel == 1 * 10)
        {
            AllEnemyKilled[1] = true;
        }
    }
    private void SpawnEnemy2()
    {
        if (EnemyToSpawn2.Length - 1 > Timer)
        {
            if (EnemyToSpawn2[Mathf.RoundToInt(Timer)] && !EnemySpawned2[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[2]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned2[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 2 + "(Clone)") == null && !AllEnemyKilled[2])
        {
            AllEnemyKilled[2] = true;
        }
        if (GameObject.Find("Inimigo" + 2 + "(Clone)") == null && UpgradesHandler.selectedLevel == 2 * 10)
        {
            AllEnemyKilled[2] = true;
        }
    }
    private void SpawnEnemy3()
    {
        if (EnemyToSpawn3.Length - 1 > Timer)
        {
            if (EnemyToSpawn3[Mathf.RoundToInt(Timer)] && !EnemySpawned3[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[3]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned3[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 3 + "(Clone)") == null && !AllEnemyKilled[3])
        {
            AllEnemyKilled[3] = true;
        }
        if (GameObject.Find("Inimigo" + 3 + "(Clone)") == null && UpgradesHandler.selectedLevel == 3 * 10)
        {
            AllEnemyKilled[3] = true;
        }
    }
    private void SpawnEnemy4()
    {
        if (EnemyToSpawn4.Length - 1 > Timer)
        {
            if (EnemyToSpawn4[Mathf.RoundToInt(Timer)] && !EnemySpawned4[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[4]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned4[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 4 + "(Clone)") == null && !AllEnemyKilled[4])
        {
            AllEnemyKilled[4] = true;
        }
        if (GameObject.Find("Inimigo" + 4 + "(Clone)") == null && UpgradesHandler.selectedLevel == 4 * 10)
        {
            AllEnemyKilled[4] = true;
        }
    }
    private void SpawnEnemy5()
    {
        if (EnemyToSpawn5.Length - 1 > Timer)
        {
            if (EnemyToSpawn5[Mathf.RoundToInt(Timer)] && !EnemySpawned5[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[5]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned5[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 5 + "(Clone)") == null && !AllEnemyKilled[5])
        {
            AllEnemyKilled[5] = true;
        }
        if (GameObject.Find("Inimigo" + 5 + "(Clone)") == null && UpgradesHandler.selectedLevel == 5 * 10)
        {
            AllEnemyKilled[5] = true;
        }
    }

    private void SpawnEnemy6()
    {
        if (EnemyToSpawn6.Length - 1 > Timer)
        {
            if (EnemyToSpawn6[Mathf.RoundToInt(Timer)] && !EnemySpawned6[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[6]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned6[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 6 + "(Clone)") == null && !AllEnemyKilled[6])
        {
            AllEnemyKilled[6] = true;
        }
        if (GameObject.Find("Inimigo" + 6 + "(Clone)") == null && UpgradesHandler.selectedLevel == 6 * 10)
        {
            AllEnemyKilled[6] = true;
        }
    }
    private void SpawnEnemy7()
    {
        if (EnemyToSpawn7.Length - 1 > Timer)
        {
            if (EnemyToSpawn7[Mathf.RoundToInt(Timer)] && !EnemySpawned7[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[7]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned7[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 7 + "(Clone)") == null && !AllEnemyKilled[7])
        {
            AllEnemyKilled[7] = true;
        }
        if (GameObject.Find("Inimigo" + 7 + "(Clone)") == null && UpgradesHandler.selectedLevel == 7 * 10)
        {
            AllEnemyKilled[7] = true;
        }
    }
    private void SpawnEnemy8()
    {
        if (EnemyToSpawn8.Length - 1 > Timer)
        {
            if (EnemyToSpawn8[Mathf.RoundToInt(Timer)] && !EnemySpawned8[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[8]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned8[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 8 + "(Clone)") == null && !AllEnemyKilled[8])
        {
            AllEnemyKilled[8] = true;
        }
        if (GameObject.Find("Inimigo" + 8 + "(Clone)") == null && UpgradesHandler.selectedLevel == 8 * 10)
        {
            AllEnemyKilled[8] = true;
        }
    }
    private void SpawnEnemy9()
    {
        if (EnemyToSpawn9.Length - 1 > Timer)
        {
            if (EnemyToSpawn9[Mathf.RoundToInt(Timer)] && !EnemySpawned9[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[9]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned9[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 9 + "(Clone)") == null && !AllEnemyKilled[9])
        {
            AllEnemyKilled[9] = true;
        }
        if (GameObject.Find("Inimigo" + 9 + "(Clone)") == null && UpgradesHandler.selectedLevel == 9 * 10)
        {
            AllEnemyKilled[9] = true;
        }
    }
    private void SpawnEnemy10()
    {
        if (EnemyToSpawn10.Length - 1 > Timer)
        {
            if (EnemyToSpawn10[Mathf.RoundToInt(Timer)] && !EnemySpawned10[Mathf.RoundToInt(Timer)])
            {
                GameObject InimigoX = Instantiate(Inimigo[10]);
                InimigoX.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
                EnemySpawned10[Mathf.RoundToInt(Timer)] = true;
            }
        }
        else if (GameObject.Find("Inimigo" + 10 + "(Clone)") == null && !AllEnemyKilled[10])
        {
            AllEnemyKilled[10] = true;
        }
        if (GameObject.Find("Inimigo" + 10 + "(Clone)") == null && UpgradesHandler.selectedLevel == 10 * 10)
        {
            AllEnemyKilled[10] = true;
        }
    }



    public GameObject MissionNo;
    public GameObject CoinDisplayFim;
    public GameObject CoinDisplay1;
    public GameObject MissionResult;
    public GameObject LostText;
    public GameObject NoEnemiesPassed;
    public GameObject ProximoNivel;
    public GameObject NoDmgBonus;
    public void Victory()
    {
        int premio = 0;
        DeathScreen.SetActive(true);
        MissionNo.GetComponent<Text>().text = "MISSION " + UpgradesHandler.selectedLevel;
        CoinDisplayFim.SetActive(true);

        MissionResult.GetComponent<Text>().text = "YOU ROCKK!!";
        LostText.SetActive(false);
        premio += UpgradesHandler.RecompensaLvl[UpgradesHandler.selectedLevel];
        UpgradesHandler.UnlockedLevels[UpgradesHandler.selectedLevel + 1] = true;
        Player1.hpFreeze = true;
        if (Player1.hp == Player1.maxHp && !UpgradesHandler.rewardClaimed[UpgradesHandler.selectedLevel])
        {
            NoDmgBonus.SetActive(true);
            premio += UpgradesHandler.RecompensaLvl[UpgradesHandler.selectedLevel];
            UpgradesHandler.rewardClaimed[UpgradesHandler.selectedLevel] = true;
        }
        for (int i = 1; i < 11; i++)
        {
            if (UpgradesHandler.selectedLevel == 10 * i && !UpgradesHandler.bossRewardClaimed[i])
            {
                UpgradesHandler.bossRewardClaimed[i] = true;
                premio += UpgradesHandler.RecompensaBoss[i];
            }
        }
        UpgradesHandler.coin += premio;
        CoinDisplay1.GetComponent<Text>().text = "" + premio + " X ";
        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().UpdateCoinDisplay();
        GameObject.Find("SavesHandler").GetComponent<UpgradesHandler>().Save();
    }
    public void Defeat()
    {
        DeathScreen.SetActive(true);
        MissionNo.GetComponent<Text>().text = "MISSION " + UpgradesHandler.selectedLevel;
        CoinDisplayFim.SetActive(false);
        MissionResult.GetComponent<Text>().text = "YOU FAILED";
        ProximoNivel.SetActive(false);
        NoEnemiesPassed.SetActive(false);

    }


}



