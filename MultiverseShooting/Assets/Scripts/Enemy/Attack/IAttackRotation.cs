using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackRotation : IEnemyAttack
{
    EnemyBulletPool bulletPool;
    Rigidbody2D rigidbody;

    float baseAngle;
    bool initialized = false;
    void IEnemyAttack.Init(EnemyBulletPool pool, Rigidbody2D rb)
    {
        bulletPool = pool;
        rigidbody = rb;

        initialized = true;
    }

    void IEnemyAttack.Fire(AttackData attackData)
    {
        if (attackData.attackCount == 0) return;

        if (initialized)
        {
            baseAngle = attackData.attackAngle;
            initialized = false;
        }

        float step = 360f / attackData.attackCount;

        for (int i = 0; i < attackData.attackCount; i++)
        {
            BulletMove bullet = bulletPool.GetBullet();
            bullet.Init(attackData.attackSpeed, baseAngle + step * i, rigidbody.position);
        }
        
        baseAngle += (int)attackData.attackUniqueParam;
    }
}
