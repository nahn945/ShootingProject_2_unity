using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOscilate : IEnemyMove
{
    float t;

    public void Init(Rigidbody2D rigidbody)
    {
        t = 0f;
    }

    // angspeedÇÕè¨Ç≥Ç≠
    public Vector2 Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        t += angspeed;

        float currentAngle = angle + Mathf.Sin(t) * enemyData.moveUniqueParam;

        float rad = currentAngle * Mathf.Deg2Rad;

        float dir = Mathf.Cos(t); // Å©í«â¡

        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * speed * dir;
    }
}