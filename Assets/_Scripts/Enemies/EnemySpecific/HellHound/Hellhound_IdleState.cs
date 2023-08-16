using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound_idleState : IdleState
{
    private Hellhound hellhound;

    public Hellhound_idleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isIdleTimeOver)
        {
            stateMachine.ChangeState(hellhound.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
