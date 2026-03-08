using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemySpawner enemySpawner;
    EnemyData enemyData;
    IEnemyMove move;
    IEnemyMove retreat;

    Rigidbody2D rb;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
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
        enemySpawner = spawner;
        move.Init(rb);
        retreat.Init(rb);

        Debug.Log("set spawn");
    }

    public void SetMovePattern(IEnemyMove pattern)
    {
        move = pattern;
    }

    public void SetRetreatPattern(IEnemyMove pattern)
    {
        retreat = pattern;
    }

    public void SetData(EnemyData input)
    {
        enemyData = input;
    }
}
