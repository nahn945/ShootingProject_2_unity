using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSingle : IEnemyBullet
{
    GameObject bulletPrefab;
    float speed;
    float angle;

    public PatternSingle(GameObject prefab, float speed, float angle)
    {
        bulletPrefab = prefab;
        this.speed = speed;
        this.angle = angle;
    }

    public void Fire(Vector3 origin, Transform target)
    {
        GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);

        bullet.GetComponent<BulletMove>().speed = speed;
        bullet.GetComponent<BulletMove>().angle = angle;
    }
}
