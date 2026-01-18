using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternNWay : IEnemyBullet
{
    GameObject bulletPrefab;
    int count;
    float spreadAngle;
    float startAngle;
    float speed;

    public PatternNWay(GameObject prefab, int count, float spreadAngle, float startAngle, float speed)
    {
        bulletPrefab = prefab;
        this.count = count;
        this.spreadAngle = spreadAngle;
        this.speed = speed;
        this.startAngle = startAngle;
    }

    public void Fire(Vector3 origin, Transform target, float defaultAngle)
    {
        float baseAngle = startAngle;

        for (int i = 0; i < count; i++)
        {
            float angle = startAngle
                - spreadAngle / 2
                + spreadAngle * i / (count - 1);

            GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);
            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().angle = defaultAngle + angle;
        }
    }
}
