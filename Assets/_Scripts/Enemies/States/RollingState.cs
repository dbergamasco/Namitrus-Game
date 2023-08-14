using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;


public class RollingState : State
{
    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    protected D_RollingState stateData;

    protected bool performCloseRangeAction;
    protected bool isPlayerinMaxAgroRange;
    protected bool isGrounded;
    protected bool isRollingOver;

    public RollingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_RollingState stateData) : base(entity, stateMachine, animBoolName)
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
            isGrounded = CollisionSenses.isGrounded;
        }
        
    }

    public override void Enter()
    {
        base.Enter();

        isRollingOver = false;

        Movement?.SetVelocity(stateData.rollingSpeed, stateData.rollingAngle, Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.rollingTime && isGrounded)
        {
            isRollingOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

