using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound_StunState : StunState
{
    private Hellhound hellhound;

    public Hellhound_StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
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

        if(isStunTimeOver)
        {
            if(performCloseRangeAction)
            {
                stateMachine.ChangeState(hellhound.meeleAttackState);
            }
            else if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(hellhound.chargeState);
            }
            else
            {
                hellhound.lookForPlayerState.SetTurnInmediately(true);
                stateMachine.ChangeState(hellhound.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
