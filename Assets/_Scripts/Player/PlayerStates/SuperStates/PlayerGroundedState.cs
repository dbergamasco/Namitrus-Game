using System;
using _Scripts;
using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private bool JumpInput;
    private bool grabInput;
    private bool dashInput;
    private bool isSubscribed = false;
    

    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName){

    }

    public override void DoCheck()
    {
        base.DoCheck();

        isGrounded = CollisionSenses.isDetectingGround();
        isTouchingWall = CollisionSenses.isDetectingWall();
    
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumps();

        

    }

    public override void Exit()
    {
        base.Exit();
 
    }
    


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;
        dashInput = player.InputHandler.DashInput;
        

        if(player.InputHandler.AttackInputs)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if(JumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        } 
        else if(!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        } 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    
    
}
