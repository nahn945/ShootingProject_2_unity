using UnityEngine;

public class PatternRotation : IEnemyBullet
{
    GameObject bulletPrefab;
    int count;
    float speed;

    float baseAngle;     // Œ»İ‚ÌŠî€Šp
    float rotateAngle;   // 1‰ñ‚Ì”­Ë‚Å‰ñ“]‚·‚éŠp“x

    static int rotateNum; // ¡‚Ü‚Å‚Ì‰ñ“]‰ñ”
    int rotateMax; // ‰½‰ñ‚Ü‚Å‰ñ“]‚·‚é‚©

    public PatternRotation(
        GameObject prefab,
        int count,
        float speed,
        float startAngle, 
        float rotateAngle,
        int rotateMax
    )
    {
        bulletPrefab = prefab;
        this.count = count;
        this.speed = speed;
        //this.baseAngle = startAngle;
        this.baseAngle = 0;
        this.rotateAngle = rotateAngle;
        this.rotateMax = rotateMax;
    }

    public void Fire(Vector3 origin, Transform target)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = 360f / count * i;
            angle += rotateAngle * rotateNum;

            GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);
            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().angle = angle;
            bullet.GetComponent<BulletMove>().isRound = false;
        }

        rotateNum = (rotateNum + 1) % rotateMax;
    }
}
