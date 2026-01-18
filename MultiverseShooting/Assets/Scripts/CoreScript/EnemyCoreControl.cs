using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoreControl : MonoBehaviour
{
    public int HP = 10;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isDead = HP <= 0;

        if (isDead)
        {
            Destroy(this.gameObject);
        }

    }

    public void DamageHP(int value)
    {

        HP -= value;

    }
}
