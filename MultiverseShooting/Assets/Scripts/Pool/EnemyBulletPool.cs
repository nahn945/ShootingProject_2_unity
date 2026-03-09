using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;

    Queue<BulletMove> pool = new Queue<BulletMove>();

    int startSize = 50;

    void Awake()
    {
        for (int i = 0; i < startSize; i++)
        {
            AddBullet();
        }
    }

    public BulletMove GetBullet()
    {
        if (pool.Count == 0)
        {
            AddBullet();
        }

        BulletMove bullet = pool.Dequeue();
        bullet.gameObject.SetActive(true);

        return bullet;
    }

    public void ReturnToPool(BulletMove bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }

    void AddBullet()
    {
        GameObject obj = Instantiate(bulletPrefab);
        obj.transform.SetParent(transform);

        BulletMove bullet = obj.GetComponent<BulletMove>();

        if (bullet == null)
        {
            Debug.LogError("BulletMove missing");
            return;
        }

        bullet.SetPool(this);

        obj.SetActive(false);

        pool.Enqueue(bullet);
    }
}