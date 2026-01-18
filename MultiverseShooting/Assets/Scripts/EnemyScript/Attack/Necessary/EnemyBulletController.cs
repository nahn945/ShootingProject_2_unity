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
        float rotationAngle,
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
            enemyBullet.Fire(this.transform.position, player, rotationAngle);
            shotTimer = 0f;
        }
    }

    public void SetRotation(
        float startTime,
        float endTime,
        float interval,
        float rotationAngle,
        IEnemyBullet enemyBullet
        )
    {
        for (int i = 0; i < (int)((endTime - startTime) / interval); i++)
        {
            SetPattern(startTime + interval * i, startTime + interval * (i+1), interval, rotationAngle * i, enemyBullet); 
        }
    }
}
