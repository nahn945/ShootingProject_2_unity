using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerFire : MonoBehaviour
{
    public GameObject bullet;

    public float interval = 0.2f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Fire()
    {
        GameObject b;
        if (timer >= interval)
        {
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            timer = 0f;
        }
    }
}
