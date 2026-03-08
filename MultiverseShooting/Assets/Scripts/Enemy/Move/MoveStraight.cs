using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : IEnemyMove
{
    Rigidbody2D rb;
    float currentSpeed;

    void IEnemyMove.Init(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    Vector2 IEnemyMove.Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2 (Mathf.Cos(rad), Mathf.Sin(rad));
        return dir * speed;
    }
}
