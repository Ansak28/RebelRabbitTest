using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State<PlayerController>
{
    Animator mAnimator;
    public PlayerIdleState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        
        if(InputManager.Instance.movement != Vector2.zero)
        {
            mFsm.ChangeState(mController.PlayerRunningState);
        }
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
        if(mController.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            InputManager.Instance.AddOnJumpHandler(Jump);
            InputManager.Instance.AddOnRollHandler(Roll);
        }
    }

    public override void OnStart()
    {
        base.OnStart();
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("IdleAnimation");
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
