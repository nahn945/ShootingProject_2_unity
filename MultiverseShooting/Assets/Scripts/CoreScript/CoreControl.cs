using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreControl : MonoBehaviour
{
    public int HP = 10;

    private bool isDead = false;

    private GameObject entity;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = HP <= 0;

        if (isDead)
        {
            Debug.Log("Dead");
        }
    }

    public void DamageHP(int value)
    {
        HP -= value;
    }
}
