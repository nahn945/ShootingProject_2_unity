using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public void Enter();
    public void Update();
    public void FixedUpdate();
    public void Exit();

}

public interface IPlayerAttackState
{
    public void Enter();
    public void Update();
    public void FixedUpdate();
    public void Exit();
}
