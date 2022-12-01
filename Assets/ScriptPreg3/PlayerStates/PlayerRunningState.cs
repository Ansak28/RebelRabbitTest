using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : State<PlayerController>
{
    Animator mAnimator;
    public PlayerRunningState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        Moverse();
        if(InputManager.Instance.movement.x == 0)
        {
            mFsm.ChangeState(mController.PlayerIdleState);
        }

    }

    public virtual void Moverse()
    {
        mController.mRb.velocity += new Vector2(InputManager.Instance.movement.x * mController.speed, mController.mRb.velocity.y);
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }

    public override void OnStart()
    {
        mAnimator=mController.GetComponent<Animator>();
        InputManager.Instance.DeleteOnJumpHandler(Jump);
        InputManager.Instance.AddOnJumpHandler(Jump);
        InputManager.Instance.AddOnRollHandler(Roll);
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
        base.OnStop();
    }
}
