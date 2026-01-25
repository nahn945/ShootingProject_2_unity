using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : StateMachine.StateBase
{
    [SerializeField] float speed = 8.0f;

    float limitY = 5.0f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    public void Update()
    {
        if (this.transform.position.y >= limitY)
        {
           
           Destroy(gameObject);
        }
    }
}
