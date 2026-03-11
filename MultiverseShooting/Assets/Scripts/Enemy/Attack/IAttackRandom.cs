using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackRandom : IEnemyAttack
{

    /*
     * uniqueParam‚ÍŠp“x‚Ì•Ï‰»—Ê
     */

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
            bullet.Init(attackData.attackSpeed * Random.Range(0.5f, 1.5f), baseAngle + step * i, rigidbody.position, false);
        }

        baseAngle += Random.Range(-(int)attackData.attackUniqueParam, (int)attackData.attackUniqueParam);
    }
}
