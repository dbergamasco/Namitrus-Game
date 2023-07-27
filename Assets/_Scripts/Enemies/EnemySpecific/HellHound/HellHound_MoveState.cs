using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound_moveState : MoveState
{
    private Hellhound hellhound;

    public HellHound_moveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.hellhound = hellhound;
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

        if(isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(hellhound.playerDetectedState);
        }
        else if(isDetectingWall || !isDetectingLedge)
        {
            hellhound.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(hellhound.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
