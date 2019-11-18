using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo : MonoBehaviour
{
    public float speed;
    public int dmg;
    public LayerMask Aliados;
    RaycastHit2D hit;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Transform>().position += new Vector3(0, -speed, 0);
        if (GetComponent<Transform>().position.y < -1 || GetComponent<Transform>().position.y > 1)
            Destroy(gameObject);
        hit = Physics2D.Raycast(GetComponent<Transform>().position - new Vector3(0, GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, -1, 0), speed, Aliados);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<Player1>().TakeDmg(dmg);
            Destroy(gameObject, .01f);
        }
    }
}
