using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Player
    public GameObject playerEntity;
    StateBase player;
    // Enemy
    StateBase enemy;
    // UI
    StateBase UI;

    public enum GameState
    {
        PLAYING,
        EVENT,
        PAUSE,
        GAMEOVER
    }

    GameState state = GameState.PLAYING;

    public abstract class StateBase : MonoBehaviour
    {
        public virtual void StaticUpdate() { }
        public virtual void DynamicUpdate() { }
    }

    private void Start()
    {
        player = playerEntity.GetComponent<StateBase>();
    }

    private void Update()
    {
        player?.StaticUpdate();
        enemy?.StaticUpdate();

        UI?.StaticUpdate();


        if (state == GameState.PLAYING)
        {
            player?.DynamicUpdate();
            enemy?.DynamicUpdate();

            enemy?.DynamicUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    void PauseGame()
    {
        if (state == GameState.PLAYING)
        {
            state = GameState.PAUSE;
        }
        else if (state == GameState.PAUSE)
        {
            state = GameState.PLAYING;
        }
    }
}