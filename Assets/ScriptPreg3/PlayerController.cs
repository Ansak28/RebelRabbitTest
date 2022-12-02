using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FiniteStateMachine<PlayerController> mFsm;
    public State<PlayerController> PlayerIdleState;
    public State<PlayerController> PlayerRunningState;
    public State<PlayerController> PlayerJumpingState;
    public State<PlayerController> PlayerRollingState;
    public State<PlayerController> PlayerFallingState;
    public float speed;
    private void Awake() 
    {
        mFsm = new FiniteStateMachine<PlayerController>();
        PlayerIdleState = new PlayerIdleState(this,mFsm);
        PlayerRunningState = new PlayerRunningState(this,mFsm);
        PlayerJumpingState = new PlayerJumpingState(this,mFsm);
        PlayerRollingState = new PlayerRollingState(this,mFsm);
        PlayerFallingState = new PlayerFallingState(this,mFsm);
    }
    void Start()
    {
        mFsm.Start(PlayerIdleState);
    }
    private void FixedUpdate() {
        mFsm.CurrentState.OnPhysicsUpdate();
    }

    void Update()
    {
        mFsm.CurrentState.HandleInput();
        mFsm.CurrentState.OnLogicUpdate();
    }
    
}
