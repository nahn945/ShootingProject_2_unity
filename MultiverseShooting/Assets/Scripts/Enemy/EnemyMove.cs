using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float angle = -90f;
    float speed = 0f;
    float retreatSpeed = 2f;
    float stopTime = 1f;
    float retreatTime = 3f;
    float retreatAngle = 90f;

    IEMove move;
    IEMove retreat;

    Rigidbody2D rb;
    Vector2 currentVelocity;
    Vector2 targetVelocity;

    float timer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        move = new IMoveStraight(angle);
        retreat = new IMoveCurve(-retreatAngle, retreatAngle);
    }

    private void FixedUpdate()
    {
        if (timer < stopTime)
        {
            rb.velocity += speed * Time.fixedDeltaTime * move.Move();
        }
        else if (timer > retreatTime)
        {
            rb.velocity += retreatSpeed * Time.fixedDeltaTime * retreat.Move();
        }
        else
        {
            rb.velocity *= 0.95f;
        }

        timer += Time.fixedDeltaTime;
    }

    public void SetData(
        float moveSpeed_,
        float moveAngle_,
        float retreatSpeed_,
        float retreatAngle_,
        float pauseTime_,
        float retreatTime_,
        int moveIndex_,
        int retreatIndex_
        )
    {
        speed = moveSpeed_;
        angle = moveAngle_;
        stopTime = pauseTime_;
        retreatTime = retreatTime_;
        retreatSpeed = retreatSpeed_;
        retreatAngle = retreatAngle_;

        switch(moveIndex_)
        {
            case 0:
                move = new IMoveStraight(angle);
                break;
            case 1:
                move = new IMoveCurve(-angle, angle);
                break;
            default:
                move = new IMoveStraight(angle);
                break;
        }

        switch(retreatIndex_)
        {
            case 0:
                retreat = new IMoveStraight(retreatAngle);
                break;
            case 1:
                retreat = new IMoveCurve(-retreatAngle, retreatAngle);
                break;
            default :
                retreat = new IMoveStraight(retreatAngle);
                break;
        }
    }
}
