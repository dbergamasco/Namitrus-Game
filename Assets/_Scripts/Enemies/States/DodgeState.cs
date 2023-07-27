using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{

    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    protected D_DodgeState stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerinMaxAgroRange;
    protected bool isGrounded;
    protected bool isDodgeOver;

    public DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DodgeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerinMaxAgroRange = entity.CheckPlayerInMaxAgroRange();

        if(CollisionSenses)
        {
            isGrounded = CollisionSenses.Ground;
        }
        
    }

    public override void Enter()
    {
        base.Enter();

        isDodgeOver = false;

        Movement?.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.dodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
