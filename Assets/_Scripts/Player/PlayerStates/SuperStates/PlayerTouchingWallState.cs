using _Scripts.CoreSystem;

public class PlayerTouchingWallState : PlayerState {
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool grabInput;
    protected bool jumpInput;
    protected bool isTouchingLedge;
    protected int xInput;
    protected int yInput;
    
    protected Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private LedgeCheckHorizontal LedgeCheckHorizontal { get => ledgeCheckHorizontal ??= core.GetCoreComponent<LedgeCheckHorizontal>(); }
    private LedgeCheckHorizontal ledgeCheckHorizontal;

    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName){

    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isGrounded = CollisionSenses.isGrounded;
        isTouchingWall = CollisionSenses.isTouchingWallFront;
        isTouchingLedge = LedgeCheckHorizontal.isTouchingHorizontalLedge;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
