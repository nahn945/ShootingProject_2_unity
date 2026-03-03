using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMoveCurve : IEMove
{
    float angle;          // 現在角度（度）
    float angularSpeed;   // 角速度（度/秒）

    public IMoveCurve(float startAngle, float angularSpeed)
    {
        this.angle = startAngle;
        this.angularSpeed = angularSpeed;
    }

    public Vector2 Move()
    {
        // 角度を更新
        angle += angularSpeed * Time.fixedDeltaTime;

        // ラジアンに変換
        float rad = angle * Mathf.Deg2Rad;

        // 方向ベクトルを返す
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }
}