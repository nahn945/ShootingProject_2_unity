using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHoming : IEnemyMove
{
    Vector2 dir;
    Rigidbody2D rb;
    bool locked = false;

    void IEnemyMove.Init(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    Vector2 IEnemyMove.Move(float angle, float speed, float angspeed, EnemyData enemyData)
    {
        if (!locked)
        {
            dir.Normalize();
            locked = true;
        }

        return dir * speed;
    }

    public void SetDir(Vector2 _dir)
    {
        dir = _dir;
    }
}
