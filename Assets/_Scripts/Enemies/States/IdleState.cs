using _Scripts.CoreSystem;
using UnityEngine;

public class IdleState : State
{

    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private LedgeCheck LedgeCheck { get => ledgeCheck ??= core.GetCoreComponent<LedgeCheck>(); }
    private LedgeCheck ledgeCheck;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    protected D_IdleState stateData;

    protected bool flipIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAgroRange;


    protected float idleTime;


    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityX(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();

    }

    public override void Exit()
    {
        base.Exit();

        if(flipIdle)
        {
            Movement?.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0f);

        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipIdle(bool flip)
    {
        flipIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
