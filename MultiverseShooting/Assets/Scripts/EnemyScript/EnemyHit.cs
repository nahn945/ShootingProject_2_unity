using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public GameObject HP;
    private HPControl control;

    // Start is called before the first frame update
    void Start()
    {
        control = HP.GetComponent<HPControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.GetIsDead())
        {
            Destroy(this.gameObject);
        }
    }
}
