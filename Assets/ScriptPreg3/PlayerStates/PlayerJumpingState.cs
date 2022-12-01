using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : State<PlayerController>
{
    Animator mAnimator;
    public PlayerJumpingState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        mController.mRb.velocity += new Vector2(InputManager.Instance.movement.x * mController.speed, mController.mRb.velocity.y);
        if(mController.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            mFsm.ChangeState(mController.PlayerIdleState);
        }
        
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("JumpAnimation");
        mController.mRb.velocity+= new Vector2(0f,2f);
    }

    public override void OnStop()
    {
        base.OnStop();
    }

}
