using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : BulletPool
{
    Queue<BulletMove> bulletQueue = new Queue<BulletMove>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            BulletMove bullet = obj.GetComponent<BulletMove>();

            bullet.SetPool(this);      // ƒv[ƒ‹‚ğ“n‚·
            obj.SetActive(false);

            bulletQueue.Enqueue(bullet);
        }
    }
}