using _Scripts.CoreSystem;
using UnityEngine;

public class DodgeState : State
{

    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

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

        performCloseRangeAction = entity.CheckPlayerInMinAgroRange();
        isPlayerinMaxAgroRange = entity.CheckPlayerInMaxAgroRange();

        if(CollisionSenses)
        {
            isGrounded = CollisionSenses.isGrounded;
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
