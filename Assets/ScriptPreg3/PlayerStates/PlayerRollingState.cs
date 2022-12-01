using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : State<PlayerController>
{
    Animator mAnimator;
    public PlayerRollingState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        mController.mRb.velocity += new Vector2(InputManager.Instance.movement.x * mController.speed *1.5f, mController.mRb.velocity.y);
        base.OnLogicUpdate();
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }
    public override void OnStart()
    {
        base.OnStart();
        mAnimator=mController.GetComponent<Animator>();
        mAnimator.Play("RollAnimation");
    }

    public override void OnStop()
    {
        base.OnStop();
    }
}
