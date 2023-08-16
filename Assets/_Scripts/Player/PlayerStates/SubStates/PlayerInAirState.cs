using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    #region Inputs Variables
    private int xInput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool grabInput;
    private bool dashInput;
    #endregion

    #region Checks Variables
    private bool isGrounded;
    private bool isTouchingWall;
    private bool oldIsTouchingWall;
    private bool isJumping;
    private bool isTouchingLedge;
    #endregion
    
    private bool coyoteTime;
    private bool wallJumpCoyoteTime;

    
    private float startWallJumpCoyoteTime;

    
    public PlayerInAirState(Player player,
                            PlayerStateMachine stateMachine,
                            PlayerData playerData,
                            string animBoolName) : base(player, stateMachine, playerData, animBoolName){
    }

    public override void DoCheck()
    {
        base.DoCheck();

        oldIsTouchingWall = isTouchingWall;

        isGrounded = CollisionSenses.isGrounded;
        isTouchingWall = CollisionSenses.isTouchingWall;

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        oldIsTouchingWall = false;

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();
        CheckWallJumpCoyoteTime();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        grabInput = player.InputHandler.GrabInput;
        dashInput = player.InputHandler.DashInput;

        CheckJumpMultiplier();
        
        if(player.InputHandler.AttackInputs)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if(isGrounded && Movement.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            coyoteTime = false;
            stateMachine.ChangeState(player.JumpState);
        }
        else 
        {
            Movement?.CheckToFlip(xInput);
            Movement?.SetVelocityX(playerData.movementVelocity * xInput);

            player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

        }
    }

    private void CheckJumpMultiplier(){
        if(isJumping)
        {
            if(jumpInputStop)
            {
                Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
 
                isJumping = false;
            } 
            else if(Movement.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyoteTime(){
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    private void CheckWallJumpCoyoteTime(){
        if(wallJumpCoyoteTime && Time.time > startWallJumpCoyoteTime + playerData.coyoteTime)
        {
            wallJumpCoyoteTime = false;
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;
    public void SetIsJumping() => isJumping = true;

    public void StartWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = true;
        startWallJumpCoyoteTime = Time.time;
    }
    public void StopWallJumpCoyoteTime() => wallJumpCoyoteTime = false;
}
