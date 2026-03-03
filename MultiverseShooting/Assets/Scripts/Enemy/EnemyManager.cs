using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyMove enemyMove;
    EnemyAttack enemyAttack;

    EnemyData enemyData;

    // Start is called before the first frame update
    void Awake()
    {
        enemyMove = GetComponent<EnemyMove>();
        enemyAttack = GetComponent<EnemyAttack>();

        if (enemyMove == null || enemyAttack == null)
        {
            Debug.LogWarning("no attachment");
        }
    }

    public void Initiallize(EnemyData inputData)
    {
        enemyData = inputData;

        if (enemyData == null)
        {
            Debug.LogError("Enemy Data is Null");
            return;
        }

        enemyMove.SetData(
            enemyData.moveSpeed,
            enemyData.moveAngle,
            enemyData.retreatSpeed,
            enemyData.retreatAngle,
            enemyData.pauseTime,
            enemyData.retreatTime,
            enemyData.moveIndex,
            enemyData.retreatIndex
            );
        enemyAttack.SetData(
            enemyData.attackSpeed,
            enemyData.attackAngle,
            enemyData.attackInterval,
            enemyData.attackIndex
            );
    }
}
