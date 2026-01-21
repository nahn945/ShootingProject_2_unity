using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicUpdate : MonoBehaviour
{
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Dynamic();
        }
    }

    protected virtual void Dynamic()
    {

    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}
