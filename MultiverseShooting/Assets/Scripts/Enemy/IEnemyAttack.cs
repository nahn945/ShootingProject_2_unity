using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttack
{
    public void Init(EnemyBulletPool pool, Rigidbody2D rb);
    public void Fire(AttackData attackData);
}
