using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackSingle : IEnemyAttack
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
        BulletMove bullet = bulletPool.GetBullet();
        //if (bullet == null) return;
        bullet.Init(attackData.attackSpeed, attackData.attackAngle, rigidbody.position);
    }
}
