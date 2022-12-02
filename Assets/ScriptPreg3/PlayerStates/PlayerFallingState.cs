using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : State<PlayerController>
{
    private Animator mAnimator;
    private CapsuleCollider2D mCollider;
    public PlayerFallingState(PlayerController controller, FiniteStateMachine<PlayerController> fsm) : base(controller, fsm)
    {
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void OnLogicUpdate()
    {
        base.OnLogicUpdate();
        if (!IsJumping()) mFsm.ChangeState(mController.PlayerIdleState);
    }

    public override void OnPhysicsUpdate()
    {
        base.OnPhysicsUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();
        mAnimator = mController.transform.GetComponent<Animator>();
        mCollider = mController.transform.GetComponent<CapsuleCollider2D>();
        mAnimator.Play("JumpAnimation");
    }

    public override void OnStop()
    {
        base.OnStop();
    }
    private bool IsJumping()
    {
        Vector3 mRaycastPointCalculated = new Vector3(
            mCollider.bounds.center.x,
            mCollider.bounds.center.y - mCollider.bounds.extents.y,
            mController.transform.position.z
        );

        RaycastHit2D hit = Physics2D.Raycast(
            mRaycastPointCalculated,
            Vector2.down,
            0.075f
        );
        if (hit)
        {
            return false;
        }else
        {
            return true;
        }
    }
}
