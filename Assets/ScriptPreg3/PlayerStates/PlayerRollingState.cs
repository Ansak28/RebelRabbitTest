using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : State<PlayerController>
{
    Animator mAnimator;
    Rigidbody2D mRb;
    public PlayerRollingState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
    }

    public override void OnPhysicsUpdate()
    {
        mRb.velocity = new Vector2(InputManager.Instance.movement.x * mController.speed *1.5f, mRb.velocity.y);
        base.OnPhysicsUpdate();
    }
    public override void OnStart()
    {
        base.OnStart();
        InputManager.Instance.AddOnReturnFromRollHandler(StopRoll);
        mRb = mController.transform.GetComponent<Rigidbody2D>();
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("RollAnimation");
    }

    private void StopRoll(object sender, EventArgs e)
    {
        mFsm.ChangeState(mController.PlayerIdleState);
    }

    public override void OnStop()
    {
        base.OnStop();
    }
}
