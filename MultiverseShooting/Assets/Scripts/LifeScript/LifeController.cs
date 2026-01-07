using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public readonly int defaultValue = 10;
    
    private bool isDead = false;
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        value = defaultValue;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = value <= 0;
    }

    public void Damage(int val)
    {
        if (value > 0)
        {
            value -= val;
        }
    }

    public bool getIsDead()
    {
        return isDead;
    }
}
