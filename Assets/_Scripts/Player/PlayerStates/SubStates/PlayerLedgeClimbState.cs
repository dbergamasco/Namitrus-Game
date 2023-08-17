using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{

    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private LedgeCheck LedgeCheck { get => ledgeCheck ??= core.GetCoreComponent<LedgeCheck>(); }
    private LedgeCheck ledgeCheck;

    private Vector2 detectedPos;
    private Vector2 cornerPos;
    private Vector2 startPos;
    private Vector2 stopPos;
    private Vector2 workspace;

    private bool isHanging;
    private bool isClimbing;
    private bool jumpInput;

    private int xInput;
    private int yInput;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName){

    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityZero();
        player.transform.position = detectedPos;
        cornerPos = DetermineCornerPosition();

        startPos.Set(cornerPos.x - (Movement.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
        stopPos.Set(cornerPos.x + (Movement.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

        player.transform.position = startPos;

    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;

        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {
            xInput = player.InputHandler.NormInputX;

            Movement?.SetVelocityZero();
            player.transform.position = startPos;

            if (xInput == Movement.FacingDirection && isHanging && !isClimbing)
            {
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;
    
    private Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(CollisionSenses.WallCheckPosition, Vector2.right * Movement.FacingDirection, CollisionSenses.WallCheckDistance, CollisionSenses.WhatIsGround);
        float xDist = xHit.distance;
        workspace.Set((xDist + 0.015f) * Movement.FacingDirection, 0f);
        RaycastHit2D yHit = Physics2D.Raycast(LedgeCheck.LedgeCheckPosition + (Vector3)(workspace), Vector2.down, LedgeCheck.LedgeCheckPosition.y - CollisionSenses.WallCheckPosition.y + 0.015f, CollisionSenses.WhatIsGround);
        float yDist = yHit.distance;

        workspace.Set(CollisionSenses.WallCheckPosition.x + (xDist * Movement.FacingDirection), LedgeCheck.LedgeCheckPosition.y - yDist);
        return workspace;
    }

}
