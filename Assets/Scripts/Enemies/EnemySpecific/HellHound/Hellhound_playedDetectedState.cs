using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound_playedDetectedState : PlayerDetectedState
{
    private Hellhound hellhound;

    public Hellhound_playedDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
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

        if(performLongRangeAction)
        {
            stateMachine.ChangeState(hellhound.chargeState);
        }
        else if(!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(hellhound.lookForPlayerstate);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
