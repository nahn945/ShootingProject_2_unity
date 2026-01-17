using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PatternRandom : IEnemyBullet
{
    GameObject bulletPrefab;
    int count;
    float speed;

    float baseAngle;
    float rotateAngle;

    public PatternRandom(
        GameObject prefab,
        int count,
        float speed,
        float startAngle,
        float rotateAngle
    )
    {
        bulletPrefab = prefab;
        this.count = count;
        this.speed = speed;
        this.baseAngle = startAngle;
        this.rotateAngle = rotateAngle;
    }

    public void Fire(Vector3 origin, Transform target)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = baseAngle + Random.Range(0f, 360f);
            GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);

            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().angle = angle;
        }

        baseAngle += Random.Range(-360f, 360f);
        baseAngle %= 360f;
    }
}
