using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackNWay : IEnemyAttack
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
        int count = attackData.attackCount;
        float step = 180f / count;

        for (int i = 0; i < count; i++)
        {
            float offset = i - (count - 1) / 2f;

            BulletMove bullet = bulletPool.GetBullet();
            bullet.Init(
                attackData.attackSpeed,
                attackData.attackAngle + step * offset,
                rigidbody.position,
                false
            );
        }
    }
}
