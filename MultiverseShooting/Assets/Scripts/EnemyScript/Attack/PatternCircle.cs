using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCircle : IEnemyBullet
{
    GameObject bulletPrefab;
    int count;
    float speed;


    public PatternCircle(GameObject prefab, int count, float speed)
    {
        bulletPrefab = prefab;
        this.count = count;
        this.speed = speed;
    }

    public void Fire(Vector3 origin, Transform target)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = 360f / count * i;

            GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);
            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().angle = angle;
        }
    }
}
