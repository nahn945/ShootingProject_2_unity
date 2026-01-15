using UnityEngine;

public class MoveArc : IEnemyMove
{
    Vector2 center;
    float radius;

    float angle;          // 現在角度（rad）
    float endAngle;       // 終了角度（rad）
    float angularSpeed;   // rad/sec
    bool finished;
    bool initialized;

    public MoveArc(
        float radius,
        float startDegree,
        float moveDegree,
        float degreePerSecond
    )
    {
        this.radius = radius;

        angle = startDegree * Mathf.Deg2Rad;
        endAngle = (startDegree + moveDegree) * Mathf.Deg2Rad;

        angularSpeed =
            Mathf.Sign(moveDegree) *
            Mathf.Abs(degreePerSecond) *
            Mathf.Deg2Rad;
    }

    public void OnStart(Rigidbody2D rb)
    {
        finished = false;

        if (!initialized)
        {
            // 弧運動開始時の位置を基準に中心を決定
            center = rb.position - Vector2.down * radius;
            initialized = true;
        }

        rb.velocity = Vector2.zero;
    }

    public void OnUpdate(Rigidbody2D rb, float deltaTime)
    {
        if (finished) return;

        angle += angularSpeed * deltaTime;

        // 終了判定
        if ((angularSpeed > 0 && angle >= endAngle) ||
            (angularSpeed < 0 && angle <= endAngle))
        {
            angle = endAngle;
            finished = true;
        }

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
