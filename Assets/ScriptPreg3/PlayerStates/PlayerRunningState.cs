using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : State<PlayerController>
{
    Animator mAnimator;
    Rigidbody2D mRb;
    public PlayerRunningState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        
        if(InputManager.Instance.movement.x == 0)
        {
            mFsm.ChangeState(mController.PlayerIdleState);
        }

    }

    public virtual void Moverse()
    {
        mRb.velocity = new Vector2(InputManager.Instance.movement.x * mController.speed, mRb.velocity.y);
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
        Moverse();
        if (mRb.velocity.x != 0f)
        {
            mController.transform.localScale = new Vector3(
                mRb.velocity.x < 0f ? -1f : 1f,
                mController.transform.localScale.y,
                mController.transform.localScale.z
            );
        }
        if(mController.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            InputManager.Instance.AddOnJumpHandler(Jump);
            InputManager.Instance.AddOnRollHandler(Roll);
        }
    }

    public override void OnStart()
    {
        mAnimator=mController.GetComponent<Animator>();
        mRb = mController.transform.GetComponent<Rigidbody2D>();
        mAnimator.Play("RunningAnimation");

    }

    private void Roll(object sender, EventArgs e)
    {
        mFsm.ChangeState(mController.PlayerRollingState);
    }

    private void Jump(object sender, EventArgs e)
    {
        
        mFsm.ChangeState(mController.PlayerJumpingState);
    }

    public override void OnStop()
    {
        InputManager.Instance.DeleteOnJumpHandler(Jump);
        InputManager.Instance.DeleteOnRollHandler(Roll);
        base.OnStop();
        
    }
}
