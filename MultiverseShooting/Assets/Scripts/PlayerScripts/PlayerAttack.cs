using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    private int timer = 0;
    private readonly int attackInterval = 60;

    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && timer >= attackInterval)
        {
            timer = 0;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (timer >= attackInterval)
            {
                timer = 0;
                Instantiate(bullet,this.transform.position, Quaternion.identity);
            }
        }

        timer += 1;
    }
}
