using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPool;
    public float interval = 0.3f;
    float timer = 0f;
    BulletPool pool;

    private void Start()
    {
        pool = bulletPool.GetComponent<BulletPool>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Z) && timer >= interval)
        {
            timer = 0f;
            BulletMove bullet = pool.GetBullet();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.gameObject.SetActive(true);
            }
        }
    }
}
