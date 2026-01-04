using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Vector2 pos;
    private float speed = 0.01f;
    
    private Vector2 dir;
    private Rigidbody2D rb;
    private float speedRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2(0, 0);
        dir = new Vector2(0, 0);
        transform.position = pos;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1;
        }

        dir.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedRate = 2.0f;
        }
        else
        {
            speedRate = 1.0f;
        }
           
        pos += dir * speed / speedRate;

        rb.MovePosition(pos);
    }
}
