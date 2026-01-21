using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    IGameState currentState;

    void Update()
    {
        currentState?.Update();
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public void ChangeState(IGameState next)
    {
        currentState?.Exit();
        currentState = next;
        currentState?.Enter();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
