using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControl : MonoBehaviour
{
    public int value = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        value -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            BulletAttack atk = collision.gameObject.GetComponent<BulletAttack>();
            Damage(atk.AttackPoint);
        }
    }
}
