using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 15.0f;
    public float limitY = 5.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= limitY)
        {
            Destroy(gameObject);
        }
    }
}
