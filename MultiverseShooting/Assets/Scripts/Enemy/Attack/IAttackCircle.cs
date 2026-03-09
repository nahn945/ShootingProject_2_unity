using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackCircle : IEnemyAttack
{
    EnemyBulletPool bulletPool;
    Rigidbody2D rigidbody;


    void IEnemyAttack.Init(EnemyBulletPool pool, Rigidbody2D rb)
    {
        bulletPool = pool;
        rigidbody = rb;
    }

    void IEnemyAttack.Fire(AttackData attackData)
    {
        if (attackData.attackCount == 0) return;

        float baseAngle = attackData.attackAngle;
        float step = 360f / attackData.attackCount;

        for (int i = 0; i < attackData.attackCount; i++)
        {
            BulletMove bullet = bulletPool.GetBullet();
            bullet.Init(attackData.attackSpeed, baseAngle + step * i, rigidbody.position);
        }
    }
}
