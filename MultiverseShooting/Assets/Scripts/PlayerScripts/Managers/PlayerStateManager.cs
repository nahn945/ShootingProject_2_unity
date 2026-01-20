using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    public Player player;
    public Rigidbody2D rb;

    public PlayerInputManager input;

    IPlayerState playerState;


    private void Start()
    {
        this.ChangeState(new StateIdle(this));
    }

    // Update is called once per frame
    void Update()
    {
        playerState?.Update();
    }

    private void FixedUpdate()
    {
        playerState?.FixedUpdate();
    }

    public void ChangeState(IPlayerState next)
    {
        playerState?.Exit();
        playerState = next;
        playerState?.Enter();
    }
}
