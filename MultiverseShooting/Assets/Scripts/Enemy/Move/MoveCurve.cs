using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCurve : IEnemyMove
{
    Rigidbody2D rb;
    float currentAngle;
    bool isInitialized = false;

    void IEnemyMove.Init(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
        currentAngle = 0f;
        isInitialized = true;
    }

    Vector2 IEnemyMove.Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        if (isInitialized)
        {
            currentAngle = angle;
            isInitialized = false;
        }

        currentAngle += angspeed;

        float rad = currentAngle * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(rad),
            Mathf.Sin(rad)
            ) * speed;
        
    }
}
