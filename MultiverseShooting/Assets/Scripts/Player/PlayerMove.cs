using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : StateMachine.StateBase
{
    Vector2 dir;
    Rigidbody2D rb;
    public float speed = 5.0f; // 外部データ

    public bool canFire = false;

    float timer = 0;

    private GameObject[] attackers = { };
    private GameObject[] attackersSlow  = { };

    private AttackerFire[] fireNormal = { };
    private AttackerFire[] fireSlow = { };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ReferenceAttacker();
    }

    public override void StaticUpdate()
    {
        rb.velocity = Vector2.zero;
    }

    public override void DynamicUpdate()
    {
        MoveSelf();
        ActivateAttacker();
    }

    void MoveSelf()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        float rate = 1f;

        if (dir.x != 0 || dir.y != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rate = 0.5f;
            }
            else
            {
                rate = 1f;
            }
            rb.velocity = dir.normalized * speed * rate;
        }
    }

    void ActivateAttacker()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                foreach (AttackerFire a in fireSlow)
                {
                    a.Fire();
                }
            }
            else
            {
                foreach (AttackerFire a in fireNormal)
                {
                    a.Fire();
                }
            }
        }
    }

    public void ReferenceAttacker()
    {
        attackers = GameObject.FindGameObjectsWithTag("Attacker");
        attackersSlow = GameObject.FindGameObjectsWithTag("AttackerSlow");

        fireNormal = new AttackerFire[attackers.Length];
        fireSlow = new AttackerFire[attackersSlow.Length];

        for (int i = 0; i < attackers.Length; i++)
        {
            fireNormal[i] = attackers[i].GetComponent<AttackerFire>();
        }
        for (int i = 0; i < attackersSlow.Length; i++)
        {
            fireSlow[i] = attackersSlow[i].GetComponent<AttackerFire>();
        }
    }
}
