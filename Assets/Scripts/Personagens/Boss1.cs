using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
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




    //Sentido do movimento na horizontal
    int mov;

    //MoveNow, Artificio para aleatoriedade do movimento horizontal
    float movN;

    //Fire Timer, Artificio para intervalo entre disparos
    float fireT;

    //Artificio para que seja executado o loop de morte apenas uma vez
    bool deathCycleDone = false;

    //hp inicial do inimigo
    public float maxHp = 10;
    public float currentHp;
    public bool Magnet;

    public GameObject ScaleHp, TextHp;

    public float Timer;
    public int SpawnFriendNow;

    public GameObject Inimigo1;

    public int EnemySpawnDelay;

    public GameObject Coin;

    public Sprite tiro2;

    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
        fireT = UnityEngine.Random.Range(shotmin, shotmax);
        tr = GetComponent<Transform>();
        bounds[0] = GameObject.Find("EnemyHandler1").GetComponent<Transform>();
        bounds[1] = GameObject.Find("EnemyHandler2").GetComponent<Transform>();

    }

    // Update is called once per frame
    private void Update()
    {

        TestHp();
        Magnet = (MenuHandlerScript.isMagnetActive);

    }


    private void TestHp()
    {
        ScaleHp.GetComponent<Transform>().localScale = new Vector3((currentHp / maxHp), ScaleHp.GetComponent<Transform>().localScale.y, ScaleHp.GetComponent<Transform>().localScale.z);
        TextHp.GetComponent<Text>().text = currentHp + "/" + maxHp;

        if (currentHp <= 0)
        {
            try
            {

                foreach (GameObject EnemyObj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    EnemyObj.GetComponent<Inimigo1>().hp = 0;
                }
                foreach (GameObject EnemyObj in GameObject.FindGameObjectsWithTag("Tiro"))
                {
                    EnemyObj.SetActive(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
            xspeed = 0;
            if (!deathCycleDone)
            {
                Destroy(GetComponent<Collider2D>());
                Destroy(gameObject, 1f);
                GetComponent<Animator>().SetBool("Explodir", true);
                deathCycleDone = true;
                for (int i = 0; i < 30; i++)
                {
                    GameObject newCoin = Instantiate(Coin);
                    newCoin.GetComponent<Transform>().position = new Vector3(tr.position.x + UnityEngine.Random.Range(-GetComponent<RectTransform>().rect.width * 2, GetComponent<RectTransform>().rect.width * 2), tr.position.y + UnityEngine.Random.Range(-GetComponent<RectTransform>().rect.height * 2, GetComponent<RectTransform>().rect.height * 2), tr.position.z);
                }
            }
        }
    }


    void FixedUpdate()
    {
        Move();

        Fire();

        SpawnFriends();
        if (currentHp / maxHp < .25)
        {
            EnemySpawnDelay = 2;
        }
    }

    private void SpawnFriends()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnFriendNow)
        {
            GameObject Inimigo = Instantiate(Inimigo1);
            Inimigo.GetComponent<Transform>().position = new Vector3(0, 1.2f, 0);
            SpawnFriendNow += EnemySpawnDelay;
        }

    }

    private void Fire()
    {
        if (fireN > fireT)
        {
            for (int i = 0; i < origem.Length; i++)
            {
                tiroI = Instantiate(tiro);
                tiroI.transform.position = origem[i].transform.position;
                if (currentHp / maxHp < .25)
                    tiroI.GetComponent<SpriteRenderer>().sprite = tiro2;
            }
            fireT = UnityEngine.Random.Range(shotmin, shotmax);
            fireN = 0;
        }
        fireN += firingRate;

    }

    private void Move()
    {
        if (tr.position.y > .8f)
        {
            tr.position += Vector3.down * 0.002f;
        }
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
    }
}
