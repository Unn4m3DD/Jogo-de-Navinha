using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroAliado : MonoBehaviour
{

    public float dmg = 1;


    public float speed;
    public LayerMask inimigos;
    public Sprite tiro, tiro2;
    RaycastHit2D hit;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        GetComponent<Transform>().position += new Vector3(0, Random.Range(speed * 0.8f, speed * 1.2f), 0);
        if (GetComponent<Transform>().position.y > 1)
            Destroy(gameObject);
        for (int i = -1; i < 2; i++)
        {
            Debug.DrawRay(GetComponent<Transform>().position + new Vector3((GetComponent<Collider2D>().bounds.size.x / 2) * i, GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, speed, 0), Color.red, 0.001f);
        }
        hit = Physics2D.Raycast(GetComponent<Transform>().position + new Vector3(0, GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, 1, 0), speed, inimigos);
        if (hit && !(GetComponent<Transform>().position.y > 1))
        {
            if (hit.collider.GetComponent<Inimigo1>() != null)
            {
                hit.collider.GetComponent<Inimigo1>().hp -= dmg;
            }
            else if (hit.collider.GetComponent<Boss1>() != null)
            {
                hit.collider.GetComponent<Boss1>().currentHp -= dmg;
            }
            Destroy(gameObject, .01f);
        }



    }
}
