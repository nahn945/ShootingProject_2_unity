using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    GameSceneUIController controller;

    float currentTime = 5.0f;
    readonly float coolTime = 5.0f;

    IEnemyBullet bomb = new BombClearPattern(3f);

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("UIManager").GetComponent<GameSceneUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isPaused) return;

        if (Input.GetKeyDown(KeyCode.X) && currentTime >= coolTime)
        {
            bomb.Fire(this.transform.position, null, 0f);
            currentTime = 0f;
        }

        currentTime += Time.deltaTime;
    }
}
