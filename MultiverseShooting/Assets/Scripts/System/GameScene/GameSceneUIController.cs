using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIController : MonoBehaviour
{
    public GameObject gameover;

    public GameObject pause;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameover.activeSelf)
        {
            if (!pause.activeSelf)
            {
                isPaused = true;
                pause.SetActive(true);
            }
            else
            {
                isPaused = false;
                pause.SetActive(false);
                
            }

        }
    }

    public void DisplayGameOver()
    {
        if (gameover.activeSelf) return;
        gameover.SetActive(true);
        isPaused = true;
    }
}
