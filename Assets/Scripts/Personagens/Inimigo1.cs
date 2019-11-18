using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inimigo1 : MonoBehaviour
{
    //FireNow, Artificio para manipular firing rate
    float fireN;

    //Referencia ao objeto instaciado durante o disparo
    public GameObject tiro;

    //Artificio para mudar a posição do disparo
    GameObject tiroI;

    //Origem da instanciação do tiro
    public Transform[] origem;

    //Transform do Inimigo1
    Transform tr;

    //Velocidade de reinstanciação do objeto tiro
    public float firingRate;

    //Intervalo de tempo entre o qual será instanciado um novo tiro
    public float shotmin, shotmax;

    //Frequencia de Mudança de Direção
    public float ChangeWayFreq;

    //Bordas do Objeto, utilizadas nos limites de moviemento
    public Transform[] bounds;

    //Velocidade horizontal padrão
    public float xspeed;

    //Velocidade vertical padrão
    public float yspeed;


    //Referencia aos objetos de Skill
    public GameObject[] Skills;


    //Probabilidade de sair Moeda
    [Range(0, 1)]
    public float probMoeda;

    //Probabilidade de sair SlowMotion
    [Range(0, 1)]
    public float probSlowMotion;

    //Probabilidade de sair BonusDmg
    [Range(0, 1)]
    public float probDmg;

    //Probabilidade de sair BonusFiringRate
    [Range(0, 1)]
    public float probBonusFiringRate;

    //Probabilidade de sair Magnet
    [Range(0, 1)]
    public float probMagnet;




    //Sentido do movimento na horizontal
    int mov;

    //MoveNow, Artificio para aleatoriedade do movimento horizontal
    float movN;

    //Fire Timer, Artificio para intervalo entre disparos
    float fireT;

    //Artificio para que seja executado o loop de morte apenas uma vez
    bool deathCycleDone = false;

    //hp inicial do inimigo
    public float hp = 10;

    public bool Magnet;


    // Use this for initialization
    void Start()
    {
        fireT = UnityEngine.Random.Range(shotmin, shotmax);
        tr = GetComponent<Transform>();
        bounds[0] = GameObject.Find("EnemyHandler1").GetComponent<Transform>();
        bounds[1] = GameObject.Find("EnemyHandler2").GetComponent<Transform>();
        if (UpgradesHandler.SkillUpgrades[0] == 0)
            probSlowMotion = 0;
        if (UpgradesHandler.SkillUpgrades[1] == 0)
            probDmg = 0;
        if (UpgradesHandler.SkillUpgrades[2] == 0)
            probBonusFiringRate = 0;
        if (UpgradesHandler.SkillUpgrades[3] == 0)
            probMagnet = 0;

    }

    // Update is called once per frame
    private void Update()
    {

        TestHp();
        Magnet = (MenuHandlerScript.isMagnetActive);

    }


    private void TestHp()
    {

        if (hp <= 0)
        {
            xspeed = yspeed = 0;
            if (!deathCycleDone)
            {

                int Drop = RandomizeDrop();
                if (Drop != -1)
                {
                    GameObject a = Instantiate(Skills[Drop]);
                    a.transform.position = tr.position;
                }
                Destroy(GetComponent<Collider2D>());
                Destroy(gameObject, 1f);
                GetComponent<Animator>().SetBool("Explodir", true);
                deathCycleDone = true;
            }
        }
        if (GetComponent<Transform>().position.y <= -1.1)
        {
            if (!deathCycleDone)
            {
                Destroy(gameObject, 1f);
                Player1.hp -= 30;
                deathCycleDone = true;
            }
        }
    }
    private int RandomizeDrop()
    {
        float rnd = UnityEngine.Random.value;
        if (0 <= rnd && rnd <= probMoeda)
        {
            return 0;
        }
        else if (probMoeda <= rnd && rnd <= probMoeda + probSlowMotion)
        {
            return 1;
        }
        else if (probMoeda + probSlowMotion <= rnd && rnd <= probMoeda + probSlowMotion + probDmg)
        {
            return 2;
        }
        else if (probMoeda + probSlowMotion + probDmg <= rnd && rnd <= probMoeda + probSlowMotion + probDmg + probBonusFiringRate)
        {
            return 3;
        }
        else if (probMoeda + probSlowMotion + probDmg + probBonusFiringRate <= rnd && rnd <= probMoeda + probSlowMotion + probDmg + probBonusFiringRate + probMagnet)
        {
            return 4;
        }

        return -1;

    }


    void FixedUpdate()
    {
        Move();

        Fire();



    }

    private void Fire()
    {
        if (fireN > fireT)
        {
            for (int i = 0; i < origem.Length; i++)
            {
                tiroI = Instantiate(tiro);
                tiroI.transform.position = origem[i].transform.position;
            }
            fireT = UnityEngine.Random.Range(shotmin, shotmax);
            fireN = 0;
        }
        fireN += firingRate;

    }

    private void Move()
    {
        if (movN > 1)
        {
            mov = Mathf.RoundToInt(UnityEngine.Random.Range(-1, 1));
            movN = 0;
        }
        movN += ChangeWayFreq;
        if (!Magnet)
        {
            if (tr.position.x < bounds[1].position.x && tr.position.x > bounds[0].position.x)
                tr.position += new Vector3(xspeed * Mathf.Sign(mov), 0, 0);
            else if (tr.position.x > bounds[0].position.x)
            {
                tr.position += new Vector3(-xspeed, 0, 0);
                mov = -1;
            }
            else if (tr.position.x < bounds[1].position.x)
            {
                tr.position += new Vector3(xspeed, 0, 0);
                mov = 1;
            }
        }
        else
        {
            if ((tr.position.x > 0 && tr.position.x < xspeed) || (tr.position.x < 0 && tr.position.x > -xspeed))
            {

            }
            else if (tr.position.x > 0)
            {
                tr.position += new Vector3(-xspeed, 0, 0);
                mov = -1;
            }
            else if (tr.position.x < 0)
            {
                tr.position += new Vector3(xspeed, 0, 0);
                mov = 1;
            }
        }
        tr.position += new Vector3(0, -yspeed, 0);
    }
}
