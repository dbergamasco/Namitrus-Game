using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerDetectedState : State
{

    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private LedgeCheckVertical LedgeCheckVertical { get => ledgeCheckVertical ??= core.GetCoreComponent<LedgeCheckVertical>(); }
    private LedgeCheckVertical ledgeCheckVertical;

    protected D_PlayerDetectedState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isDetectingLedge;

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();

        if(CollisionSenses)
        {
            isDetectingLedge = LedgeCheckVertical.isTouchingVerticalLedge;
        }
        
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityX(0f);
        performLongRangeAction = false; 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0f);

        if(Time.time > startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
