using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMove
{
    public void Init(Rigidbody2D rigidbody);
    public Vector2 Move(float angle, float speed, float angspeed, EnemyData enemyData);
}
