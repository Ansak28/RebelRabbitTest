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
    }

    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("IDLE");
        InputManager.Instance.DeleteOnJumpHandler(Jump);
        InputManager.Instance.AddOnJumpHandler(Jump);
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("IdleAnimation");
        
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
