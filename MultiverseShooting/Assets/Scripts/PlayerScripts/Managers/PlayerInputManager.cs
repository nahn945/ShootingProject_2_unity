using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInputActions actions;

    Vector2 moveInput;
    bool slow;
    bool isAttacking;

    public Vector2 MoveInput => moveInput;
    public bool IsSlow => slow;

    public bool IsAttacking => isAttacking;

    void Awake()
    {
        actions = new PlayerInputActions();
    }

    void OnEnable()
    {
        actions.Player.Enable();
    }

    void OnDisable()
    {
        actions.Player.Disable();
    }

    void Update()
    {
        moveInput = actions.Player.Move.ReadValue<Vector2>();
        slow = actions.Player.Slow.IsPressed();
        isAttacking = actions.Player.Attack.IsPressed();
    }
}
