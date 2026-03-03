using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float speed = 13f;

    Rigidbody2D rb;

    // 自分を返す先（プール管理者）
    BulletPool pool;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // プールをセットするための初期化関数
    public void SetPool(BulletPool _pool)
    {
        pool = _pool;
    }

    void OnEnable()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnBecameInvisible()
    {
        ReturnToQueue();
    }

    void ReturnToQueue()
    {
        rb.velocity = Vector2.zero;
        pool.ReturnBullet(this);   // 自分をプールに返す
    }

    public void SetSpeed(float val)
    {
        speed = val;
    }
}