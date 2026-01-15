using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    // IEnemyMove ÇÃä«óùóp
    Rigidbody2D rb;
    IEnemyMove enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMove(IEnemyMove move)
    {
        enemyMove?.OnEnd(rb);
        enemyMove = move;
        enemyMove?.OnStart(rb);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyMove?.OnUpdate(rb, Time.fixedDeltaTime);
    }
}
