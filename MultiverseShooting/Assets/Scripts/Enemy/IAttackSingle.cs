using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttackSingle : IEAttack
{
    void IEAttack.Fire(EnemyAttack enemyAttack, float angle)
    {
        enemyAttack.makeBullet(angle);
    }
}
