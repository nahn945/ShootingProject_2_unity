using UnityEngine;

public class PatternRotation : IEnemyBullet
{
    GameObject bulletPrefab;
    int count;
    float speed;

    float currentAngle;   // ★ 毎回更新される基準角
    float rotateAngle;

    public PatternRotation(
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
        this.currentAngle = startAngle;
        this.rotateAngle = rotateAngle;
    }

    public void Fire(Vector3 origin, Transform target, float defaultAngle)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = 360f / count * i + currentAngle;

            GameObject bullet = Object.Instantiate(bulletPrefab, origin, Quaternion.identity);
            var move = bullet.GetComponent<BulletMove>();
            move.speed = speed;
            move.angle = defaultAngle + angle;
        }

        // ★ 次回のために基準角を更新
        currentAngle += rotateAngle;
        currentAngle %= 360f; // 任意（数値安定用）
    }
}
