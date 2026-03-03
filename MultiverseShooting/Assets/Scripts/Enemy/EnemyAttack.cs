using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPool;
    float angle = -30;
    BulletPool pool;
    float interval = 1f;
    float timer = 0f;
    float attackSpeed = 2f;

    IEAttack attack;

    private void Awake()
    {
       
        pool = bulletPool.GetComponent<EnemyBulletPool>();
        if (pool == null)
        {
            Debug.LogWarning("no pool");
        }
        attack = new IAttackSingle();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > interval)
        {
            attack.Fire(this, angle);
            timer = 0f;
        }
    }

    public void makeBullet(float ang)
    {
        BulletMove bullet = pool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, ang);
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<BulletMove>().SetSpeed(attackSpeed);
        }
    }

    public void SetData(
        float attackSpeed_,
        float attackAngle_,
        float attackInterval_,
        int attackIndex
        )
    {
        attackSpeed = attackSpeed_;
        angle = attackAngle_;
        interval = attackInterval_;

        switch(attackIndex)
        {
            case 0:
                attack = new IAttackSingle(); 
                break;

            default:
                attack = new IAttackSingle();
                break;
        }
    }
}
