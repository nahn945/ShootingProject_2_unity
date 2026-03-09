using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    EnemyBulletPool bulletPool;

    float speed = 5.0f;
    float angle = 0f;

    float rad;
    Rigidbody2D rb;

    bool isHoming = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        rad = angle * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * speed;
        rb.MovePosition(rb.position + Time.fixedDeltaTime * dir);
    }

    private void OnBecameInvisible()
    {
        if (bulletPool.gameObject.activeSelf)
        {
            return;
        }

        bulletPool.gameObject.SetActive(false);
        bulletPool.ReturnToPool(this);
    }

    public void Init(float _speed, float _angle, Vector2 pos)
    {
        speed = _speed;
        angle = _angle;
        rb.position = pos;
    }

    public void SetPool(EnemyBulletPool pool)
    {
        bulletPool =  pool;
    }

    public EnemyBulletPool GetPool()
    {
        return bulletPool;
    }
}
