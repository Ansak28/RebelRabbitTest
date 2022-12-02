using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : State<PlayerController>
{
    Animator mAnimator;
    private Rigidbody2D mRb;
    public PlayerJumpingState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        
        base.OnLogicUpdate();     
        if (mRb.velocity.y < 0) mFsm.ChangeState(mController.PlayerFallingState);
        
        
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();        
    }

    public override void OnStart()
    {
        base.OnStart();
        mRb = mController.transform.GetComponent<Rigidbody2D>();
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("JumpAnimation");
        mRb = mController.transform.GetComponent<Rigidbody2D>();
        mRb.velocity += Vector2.up*15f;
        
        
    }

    public override void OnStop()
    {
        
        base.OnStop();
    }

}
