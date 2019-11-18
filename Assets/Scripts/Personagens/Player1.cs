using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Player1 : MonoBehaviour
{
    //Transform da Nave
    Transform tr;
    //Prefab Tiro
    public GameObject tiro;
    //Transform da origem dos tiros
    public Transform[] origem;
    //Artificio para mudar posição da instanciação
    GameObject tiroI;
    //Firing rate
    public float firingRate;
    //FireNow, usado para setar timer na cadencia de tiros
    float fireN;
    //Variaveis de vida
    public static float maxHp;
    public static float hp;

    //Variaveis de Mana
    public static float maxMana;
    public static float mana;

    public int coins;

    //Variavel utilizada para parar atividade da nave após morrer
    bool freeze = false;

    //Maximo de skills que podem ser acumulados
    public int maxSkillStorage;
    //Skills que estão acumulados
    public int[] skillStored;
    //Botões onde estão os skills
    public GameObject[] SkillSlot;
    //Sprites dos Skills
    public Sprite[] skillSprite;
    //Velocidade Horizontal
    public float xspeed;
    //A eliminar
    GameObject DisplayVida, DisplayMana, DisplayVidaTxt, DisplayManaTxt;
    //Multiplicador de dano (Power Ups...)
    public float dmgMultiplier;
    //Dano Base Do tiro
    public int BaseDmg;

    //Chance de Critico
    public float CriticalChance;

    //Bordas
    public GameObject[] borders;

    //Posições rato
    Vector2 pos1;

    public static bool hpFreeze;

    //Sprites Naves
    public Sprite[] SpriteNave;
    public int pathNave;
    float a = 0;

    public Sprite tiro2;

    public GameObject RecieveDamage;

    void Start()
    {
        RecieveDamage = GameObject.Find("Damage");
        RecieveDamage.SetActive(false);
        DisplayVida = GameObject.Find("VidaAtual");
        DisplayMana = GameObject.Find("ManaAtual");
        DisplayVidaTxt = GameObject.Find("VidaAtualTxt");
        DisplayManaTxt = GameObject.Find("ManaAtualTxt");
        skillStored = new int[maxSkillStorage + 1];
        tr = GetComponent<Transform>();
        borders = new GameObject[2];
        borders[0] = GameObject.Find("EnemyHandler0");
        borders[1] = GameObject.Find("EnemyHandler1");
        try
        {
            GetComponent<Animator>().SetInteger("NavePath", pathNave);
        }
        catch (Exception)
        {
        }
        for (int i = 1; i < 4; i++)
        {
            SkillSlot[i] = GameObject.Find("SkillSlot" + i);
            SkillSlot[i].SetActive(false);
        }
    }



    void Update()
    {
        //testa a vida atual da nave e realiza a função de morte se vida <= 0
        TestHp();

        DisplayVida.GetComponent<Transform>().localScale = new Vector3(hp / maxHp, DisplayVida.GetComponent<Transform>().localScale.y, DisplayVida.GetComponent<Transform>().localScale.z);
        if (Player1.maxMana != 0)
            DisplayMana.GetComponent<Transform>().localScale = new Vector3(mana / maxMana, DisplayMana.GetComponent<Transform>().localScale.y, DisplayMana.GetComponent<Transform>().localScale.z);
        DisplayVidaTxt.GetComponent<Text>().text = "" + hp + "/" + maxHp;
        DisplayManaTxt.GetComponent<Text>().text = "" + mana + "/" + maxMana;
        //DisplayMoedas.text = "Moedas: " + coins;


        //GetComponent<SpriteRenderer>().sprite = SpriteNave[pathNave];
    }


    private void FixedUpdate()
    {
        if (!freeze)
        {
            //Dispara os tiros 
            Fire();
            //Move a nave fazendo a seguir o rato
            Move();
        }
    }
    public void TakeDmg(int Dmg)
    {
        if (!hpFreeze)
            hp -= Dmg;
        StartCoroutine(TemporarilyDeactivate(.05f));
    }
    private IEnumerator TemporarilyDeactivate(float duration)
    {
        RecieveDamage.SetActive(true);
        yield return new WaitForSeconds(duration);
        RecieveDamage.SetActive(false);
    }

    public void StoreSkill(int skillType)
    {
        for (int i = 1; i < skillStored.Length; i++)
        {
            if (skillStored[i] == 0)
            {
                skillStored[i] = skillType;
                SkillSlot[i].SetActive(true);
                SkillSlot[i].GetComponent<Image>().sprite = skillSprite[skillType];
                break;
            }

        }
    }

    public void DeleteUsedSkill(int skillSlot)
    {
        skillStored[skillSlot] = 0;

    }

    private void TestHp()
    {
        if (hp <= 0)
        {
            hp = 0;
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 1f);
            GetComponent<Animator>().SetBool("Explodir", true);
            freeze = true;
        }
    }

    private void Move()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(1))
            {
                pos1 = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0);
                a = tr.position.x;
            }
            if (Input.GetMouseButton(1))
            {
                tr.position = new Vector2(a + Camera.main.ScreenToWorldPoint(Input.mousePosition).x - pos1.x, tr.position.y);
            }
        }
        else
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                pos1 = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0);
                a = tr.position.x;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                tr.position = new Vector2(a + Camera.main.ScreenToWorldPoint(touch.position).x - pos1.x, tr.position.y);
            }
        }
    }

    private void Fire()
    {
        if (fireN > 1)
        {
            for (int i = 0; i < origem.Length; i++)
            {
                tiroI = Instantiate(tiro);
                tiroI.GetComponent<TiroAliado>().dmg = BaseDmg;
                tiroI.GetComponent<TiroAliado>().dmg *= dmgMultiplier;
                if (dmgMultiplier != 1)
                    tiroI.GetComponent<SpriteRenderer>().sprite = tiro2;
                if (UnityEngine.Random.value < CriticalChance)
                    tiroI.GetComponent<TiroAliado>().dmg *= 2;

                tiroI.transform.position = origem[i].transform.position;
            }
            fireN = 0;
        }
        fireN += firingRate;
    }
}
