using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControl : MonoBehaviour
{
    public int value = 10;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value <= 0)
        {
            isDead = true;
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
