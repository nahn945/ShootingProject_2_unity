using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreControl : MonoBehaviour
{
    public int HP = 10;

    public readonly float invincibleSec = 1.0f;
    private float timer = 0;
    private bool isTimerMoving = false;

    private bool isDead = false;

    private GameObject entity;

    private GameSceneUIController UI;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<GameObject>();
        timer = invincibleSec;

        UI = GameObject.FindWithTag("UIManager").GetComponent<GameSceneUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = HP <= 0;

        if (isDead)
        {
            UI.DisplayGameOver();
        }

        if (isTimerMoving)
        {
            if (timer <= invincibleSec)
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void DamageHP(int value)
    {
        
        if (timer >= invincibleSec)
        {
            Debug.Log("hit");
            HP -= value;
            timer = 0f;
        }

        isTimerMoving = true;

    }
}
