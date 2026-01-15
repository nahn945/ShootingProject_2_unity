using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowGround : MonoBehaviour
{
    EnemyMoveController moveController;

    PatternPresets presets;
    

    // Start is called before the first frame update
    void Start()
    {
        moveController = GetComponent<EnemyMoveController>();
        presets = GetComponent<PatternPresets>();
    }

    // Update is called once per frame
    void Update()
    {
        presets.timer += Time.deltaTime;

        SetMove(0f, 2.0f, new MoveStraight(-90, presets.speed));
        SetMove(2.0f, presets.ENDLESS, new MoveArc(presets.radius, -90, 60, 10));
    }

    public void SetMove(float startTime, float endTime, IEnemyMove enemyMove)
    {
        if (presets.timer >= startTime)
        {
            moveController.SetMove(
                    enemyMove
                );
        }

        if (endTime != presets.ENDLESS)
        {
            if (presets.timer >= endTime)
            {
                moveController.SetMove(null);
                enabled = false;
            }
        }
    }
}
