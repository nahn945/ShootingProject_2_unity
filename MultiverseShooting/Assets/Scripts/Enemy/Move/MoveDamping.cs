using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDamping : IEnemyMove
{
    Rigidbody2D rb;
    float currentSpeed;
    bool isInitialized = false;

    void IEnemyMove.Init(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
        isInitialized = true;
    }

    Vector2 IEnemyMove.Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        if (isInitialized)
        {
            currentSpeed = speed;
            isInitialized = false;
        }
        else
        {
            if (currentSpeed >= 0.1f)
            {
                currentSpeed *= 0.95f;
            }
            else
            {
                currentSpeed = 0f;
            }
        }

        float rad = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        return dir * currentSpeed;
    }
}
