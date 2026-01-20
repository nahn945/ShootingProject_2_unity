using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateIdle : IPlayerState
{
    PlayerStateManager stateManager;
    float x;
    float y;

    public StateIdle(PlayerStateManager manager)
    {
        stateManager = manager;
    }

    void IPlayerState.Enter()
    {
        Debug.Log("Player: Entered the state IDLE");
    }

    void IPlayerState.Exit()
    {
        Debug.Log("Player: Exited the state IDLE");
        // 待機アニメーション開始など
    }

    void IPlayerState.FixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    void IPlayerState.Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            stateManager.ChangeState(new StateMove(stateManager));
        }

    }
}
