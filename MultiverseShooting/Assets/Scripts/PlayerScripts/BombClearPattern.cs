using UnityEngine;

public class BombClearPattern : IEnemyBullet
{
    float radius;

    public BombClearPattern(float radius)
    {
        this.radius = radius;
    }

    public void Fire(Vector3 origin, Transform target, float baseAngle)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(origin, radius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("EnemyBullet") || hit.CompareTag("GrazeArea"))
            {
                Object.Destroy(hit.gameObject);
            }
        }
    }
}
