using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;

    Queue<BulletMove> bulletQueue = new Queue<BulletMove>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            BulletMove bullet = obj.GetComponent<BulletMove>();

            bullet.SetPool(this);      // ƒv[ƒ‹‚ð“n‚·
            obj.SetActive(false);

            bulletQueue.Enqueue(bullet);
        }
    }

    public BulletMove GetBullet()
    {
        if (bulletQueue.Count > 0)
        {
            BulletMove bullet = bulletQueue.Dequeue();
            //bullet.gameObject.SetActive(true);
            return bullet;
        }

        return null;
    }

    public void ReturnBullet(BulletMove bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletQueue.Enqueue(bullet);
    }
}