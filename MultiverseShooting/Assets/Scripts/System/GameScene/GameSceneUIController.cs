using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIController : MonoBehaviour
{
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOver()
    {
        if (gameover.activeSelf) return;
        gameover.SetActive(true);
        Time.timeScale = 0f;
    }
}
