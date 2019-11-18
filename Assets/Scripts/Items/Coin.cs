using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool hitLoopDone = false;
    public float speed;
    public GameObject uH;
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
        Debug.DrawRay(GetComponent<Transform>().position + new Vector3(-GetComponent<Collider2D>().bounds.size.x / 2, -GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, -speed, 0), Color.red, 0.001f);
        Debug.DrawRay(GetComponent<Transform>().position + new Vector3(GetComponent<Collider2D>().bounds.size.x / 2, -GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, -speed, 0), Color.red, 0.001f);
        for (int i = -1; i < 2; i += 2)
        {
            hit = Physics2D.Raycast(GetComponent<Transform>().position + new Vector3(i * GetComponent<Collider2D>().bounds.size.x / 2, -GetComponent<Collider2D>().bounds.size.y / 2, 0), new Vector3(0, -1, 0), speed, Aliados);
            if (hit && !hitLoopDone)
            {
                uH = GameObject.Find("SavesHandler");
                uH.GetComponent<UpgradesHandler>().CoinAdd();
                Destroy(gameObject, .01f);
                hitLoopDone = true;
            }
        }

    }
}
