using _Scripts.CoreSystem;

public class MoveState : State
{

    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private LedgeCheckVertical LedgeCheckVertical { get => ledgeCheckVertical ??= core.GetCoreComponent<LedgeCheckVertical>(); }
    private LedgeCheckVertical ledgeCheckVertical;

    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        if(CollisionSenses)
        {
        isDetectingLedge = LedgeCheckVertical.isTouchingVerticalLedge;
        isDetectingWall = CollisionSenses.isTouchingWallFront;
        }
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(stateData.movementSpeed * Movement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
