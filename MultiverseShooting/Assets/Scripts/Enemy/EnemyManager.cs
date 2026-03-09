using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemyBulletPool pool;

    EnemySpawner enemySpawner;
    EnemyData enemyData;
    AttackData attackData;
    IEnemyMove move;
    IEnemyMove retreat;
    IEnemyAttack attack;

    Rigidbody2D rb;
    float timer = 0f;
    float attackTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!gameObject.activeSelf) return;

        Vector2 moveVec = Vector2.zero;

        if (timer >= enemyData.retreatTime)
        {
            moveVec = retreat.Move(
                enemyData.retreatAngle, 
                enemyData.retreatSpeed, 
                enemyData.retreatAngleSpeed,
                enemyData
                );
            rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
            return;
        }


        if (move != null)
        {
            moveVec = move.Move(
                enemyData.moveAngle,
                enemyData.moveSpeed,
                enemyData.moveAngleSpeed,
                enemyData
                );
            rb.MovePosition(rb.position + moveVec * Time.fixedDeltaTime);
        }

        if (attack != null && timer >= enemyData.spawnTime + attackData.attackTime)
        {
            if (attackTimer >= attackData.attackInterval)
            {
                attack.Fire(attackData);
                attackTimer = 0f;
            }
        }

        attackTimer += Time.fixedDeltaTime;
        timer += Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        timer = 0f;
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        enemySpawner.EnequeueSelf(this);
    }

    public void Init(EnemySpawner spawner)
    {
        Debug.Log("init start");
        attackData = enemyData.attackData;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("rb get");

        enemySpawner = spawner;
        move.Init(rb);
        retreat.Init(rb);
        attack.Init(pool, rb);

        Debug.Log("init end");
    }

    public void SetMovePattern(IEnemyMove pattern)
    {
        move = pattern;
    }

    public void SetRetreatPattern(IEnemyMove pattern)
    {
        retreat = pattern;
    }

    public void SetAttackPattern(IEnemyAttack pattern)
    {
        attack = pattern;
    }

    public void SetData(EnemyData input)
    {
        enemyData = input;
        Debug.Log("Data set");
    }

    public void SetPool(EnemyBulletPool bulletPool)
    {
        pool = bulletPool;
        Debug.Log("Set Pool");
    }
}
