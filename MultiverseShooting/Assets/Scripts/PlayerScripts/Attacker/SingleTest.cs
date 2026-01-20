using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTest : MonoBehaviour
{
    public GameObject bullet;
    public float interval = 0.5f;

    public PlayerInputManager input;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (input.IsAttacking && timer >= interval)
        {
            Fire(bullet);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public void Fire(GameObject bullet)
    {
        Instantiate(bullet, this.transform.position, Quaternion.identity);
    }
}
