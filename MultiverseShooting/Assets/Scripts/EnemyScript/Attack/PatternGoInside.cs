using UnityEngine;

public class PatternGoInside : CrossPatternBase
{
    float angle;

    public PatternGoInside(
        GameObject bullet,
        int count,
        float speed,
        bool homing,
        float angle
    ) : base(bullet, count, speed, homing)
    {
        this.angle = angle;
    }

    protected override void SetCrossAngle(
        BulletMove move,
        float baseAngle,
        int index
    )
    {
        move.crossAngle = angle + 180f;
    }
}
