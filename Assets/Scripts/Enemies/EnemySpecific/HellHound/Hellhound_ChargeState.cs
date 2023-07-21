using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound_ChargeState : ChargeState
{
    private Hellhound hellhound;

    public Hellhound_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.hellhound = hellhound;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if(!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(hellhound.lookForPlayerstate);
        }
        else if(isChargeTimeOver)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(hellhound.playerDetectedState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
