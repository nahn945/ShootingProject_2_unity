using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurning : IEnemyMove
{
    float t;
    bool initialized;

    public void Init(Rigidbody2D rigidbody)
    {
        t = 0f;
        initialized = true;
    }

    public Vector2 Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        float rad = angle * Mathf.Deg2Rad;
        t += 1.0f;
        t %= 360f;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * speed * Mathf.Cos(t * Mathf.Deg2Rad);
    }
}