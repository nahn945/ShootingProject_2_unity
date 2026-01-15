using UnityEngine;
using UnityEngine.UIElements;

public class MoveStraight : IEnemyMove
{
    Vector2 dir;
    float speed;

    public MoveStraight(float degree, float speed)
    {
        float rad = degree * Mathf.Deg2Rad;
        dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        this.speed = speed;
    }

    public void OnStart(Rigidbody2D rb) { }

    public void OnUpdate(Rigidbody2D rb, float dt)
    {
        rb.velocity = dir * speed;
    }

    public void OnEnd(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}