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
    public float speed;
    public Rigidbody2D mRb;
    private void Awake() 
    {
        mFsm = new FiniteStateMachine<PlayerController>();
        mRb = GetComponent<Rigidbody2D>();
        PlayerIdleState = new PlayerIdleState(this,mFsm);
        PlayerRunningState = new PlayerRunningState(this,mFsm);
        PlayerJumpingState = new PlayerJumpingState(this,mFsm);
        PlayerRollingState = new PlayerRollingState(this,mFsm);
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
