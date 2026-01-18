using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBullet
{
    void Fire(Vector3 origin, Transform target, float defaultAngle);
}
