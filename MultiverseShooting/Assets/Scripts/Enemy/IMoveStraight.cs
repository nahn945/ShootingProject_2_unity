using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMoveStraight : IEMove
{
    float angle;
    Vector2 dir;

    public IMoveStraight(float angle_)
    {
        angle = angle_;
    }

    Vector2 IEMove.Move()
    {
        dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        return dir;
    }
}
