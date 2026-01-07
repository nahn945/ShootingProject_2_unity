using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCircleController : MonoBehaviour
{
    private bool isHit = false;
    private int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isHit = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            isHit = true;
            // オブジェクトからダメージ値を持ってくる
        }
    }

    public bool getIsHit()
    {
        return isHit;
    }

    public int getDamage()
    {
        return damage;
    }
}