using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{

    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private LedgeCheckHorizontal LedgeCheckHorizontal { get => ledgeCheckHorizontal ??= core.GetCoreComponent<LedgeCheckHorizontal>(); }
    private LedgeCheckHorizontal ledgeCheckHorizontal;

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

        player.transform.position = detectedPos;
        Debug.Log("Player pos after setting = "+ player.transform.position);
        Debug.Log("player ledge offset position: "+ LedgeCheckHorizontal.ledgeCheckPosition);

        Movement?.SetVelocityZero();
        
        cornerPos = LedgeCheckHorizontal.ledgeCheckPosition;

        startPos = detectedPos;
        Vector2 diagonalDirection = new Vector2(Movement.FacingDirection, 1);
        float distance = 0.7f;

        Vector2 normalizedDirection = diagonalDirection.normalized;
        stopPos = startPos + normalizedDirection * distance;

        

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
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;

            Movement?.SetVelocityZero();
            player.transform.position = startPos;

            if (xInput == Movement.FacingDirection && isHanging && !isClimbing)
            {
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if(yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

}
