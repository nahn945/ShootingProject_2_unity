using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Transform player;

    float timer = 0f;
    float shotTimer = 0f;

    public bool isExpired = false;

    void Update()
    {
        timer += Time.deltaTime;
        shotTimer += Time.deltaTime;
        
    }

    public void SetPattern(
        float startTime,
        float endTime,
        float interval,
        IEnemyBullet enemyBullet
    )
    {
        if (timer < startTime)
        {
            return;
        }

        if (timer > endTime)
        {
            isExpired = true;
            return;
        }

        if (shotTimer >= interval)
        {
            enemyBullet.Fire(this.transform.position, player);
            shotTimer = 0f;
        }
    }
}
