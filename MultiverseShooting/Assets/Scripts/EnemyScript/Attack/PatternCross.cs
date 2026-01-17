using UnityEngine;

public class PatternCross : CrossPatternBase
{
    float crossOffset;

    public PatternCross(
        GameObject bullet,
        int count,
        float speed,
        bool homing,
        float crossOffset
    ) : base(bullet, count, speed, homing)
    {
        this.crossOffset = crossOffset;
    }

    protected override void SetCrossAngle(
        BulletMove move,
        float baseAngle,
        int index
    )
    {
        move.crossAngle = (index == 0)
            ? crossOffset
            : -crossOffset;
    }
}
