using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{

    private int wallJumpDirection;
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName){
        
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.UseJumpInput();
        player.JumpState.ResetAmountOfJumps();
        core.Movement.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDirection);
        core.Movement.CheckToFlip(wallJumpDirection);
        player.JumpState.DecreaseAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.Anim.SetFloat("yVelocity",core.Movement.CurrentVelocity.y);
        player.Anim.SetFloat("xVelocity", Mathf.Abs(core.Movement.CurrentVelocity.x));

        if (Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection(bool isTouchingWall){
        if(isTouchingWall)
        {
            wallJumpDirection = -core.Movement.FacingDirection;
        }
        else
        {
            wallJumpDirection = core.Movement.FacingDirection;
        }
    }

}