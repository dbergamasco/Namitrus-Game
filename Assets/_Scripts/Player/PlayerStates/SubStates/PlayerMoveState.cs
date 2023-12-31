public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player,
                           PlayerStateMachine stateMachine,
                           PlayerData playerData,
                           string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }



    public override void DoCheck()
    {
        base.DoCheck();
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
        
        Movement?.CheckToFlip(xInput);

        Movement?.SetVelocityX(playerData.movementVelocity * xInput);

        if(xInput == 0 && !isExitingState)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
