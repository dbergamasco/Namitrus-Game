public class PlayerWallClimbState : PlayerTouchingWallState {
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName){

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            Movement?.SetVelocityY(playerData.wallClimbVelocity);
        }
        
    }
}
