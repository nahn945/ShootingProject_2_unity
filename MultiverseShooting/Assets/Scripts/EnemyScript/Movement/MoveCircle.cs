using UnityEngine;

public class MoveCircle : IEnemyMove
{
    Vector2 center;
    float radius;
    float angle;
    float angularSpeed;

    bool initialized = false;

    public MoveCircle(float radius, float startDegree, float degreePerSecond)
    {
        this.radius = radius;
        angle = startDegree * Mathf.Deg2Rad;
        angularSpeed = degreePerSecond * Mathf.Deg2Rad;
    }

    public void OnStart(Rigidbody2D rb)
    {
        if (!initialized)
        {
            // 円運動開始時の位置を基準に中心を決定
            center = rb.position;
            center.y += radius;

            initialized = true;
        }
    }

    public void OnUpdate(Rigidbody2D rb, float dt)
    {
        angle += angularSpeed * dt;

        Vector2 pos = center + new Vector2(
            Mathf.Cos(angle),
            Mathf.Sin(angle)
        ) * radius;

        rb.MovePosition(pos);
    }

    public void OnEnd(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
