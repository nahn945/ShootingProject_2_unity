using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateMove : IPlayerState
{
    PlayerStateManager stateManager;

    float horizontal;
    float vertical;

    float rate;

    Vector2 moveDir = Vector2.zero;
    bool isSlow;

    public StateMove(PlayerStateManager manager)
    {
        this.stateManager = manager;
    }

    void IPlayerState.Enter()
    {
        Debug.Log("Player: Entered the state MOVE");
    }

    void IPlayerState.Exit()
    {
        Debug.Log("Player: Exit the state MOVE");
    }

    void IPlayerState.FixedUpdate()
    {
        stateManager.rb.velocity = moveDir * stateManager.player.speed * ((isSlow)? 0.5f : 1f);
    }

    void IPlayerState.Update()
    {
        isSlow = stateManager.input.IsSlow;
        moveDir = stateManager.input.MoveInput;
    }
}
