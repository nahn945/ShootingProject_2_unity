using UnityEngine;

public abstract class CrossPatternBase : IEnemyBullet
{
    protected GameObject bullet;
    protected Vector3 pos;

    protected int count;
    protected float speed;
    protected bool homing;

    public CrossPatternBase(
        GameObject bullet,
        int count,
        float speed,
        bool homing
    )
    {
        this.bullet = bullet;
        this.count = count;
        this.speed = speed;
        this.homing = homing;
    }

    public void Fire(Vector3 origin, Transform target, float defaultAngle)
    {
        pos = origin;

        for (int i = 0; i < count; i++)
        {
            float baseAngle = 360f / count * i;

            CreatePair(baseAngle);
        }
    }

    protected void CreatePair(float baseAngle)
    {
        for (int j = 0; j < 2; j++)
        {
            GameObject b = Object.Instantiate(bullet, pos, Quaternion.identity);
            var m = b.GetComponent<BulletMove>();

            m.isHoming = homing;
            m.angle = baseAngle;
            m.speed = speed;
            m.isCross = true;

            SetCrossAngle(m, baseAngle, j);
        }
    }

    /// <summary>
    /// ÉpÉ^Å[ÉìÇ≤Ç∆ÇÃç∑ï™
    /// </summary>
    protected abstract void SetCrossAngle(
        BulletMove move,
        float baseAngle,
        int index
    );
}
