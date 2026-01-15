using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMove
{
    void OnStart(Rigidbody2D rb);
    void OnUpdate(Rigidbody2D rb, float deltaTime);
    void OnEnd(Rigidbody2D rb);
}