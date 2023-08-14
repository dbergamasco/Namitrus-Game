using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Archer_RollingState : RollingState
{
    private Archer archer;

    public Archer_RollingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_RollingState stateData, Archer archer) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.archer = archer;
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

        if(isRollingOver)
        {
            if(isPlayerinMaxAgroRange && performCloseRangeAction)
            {
                stateMachine.ChangeState(archer.meleeAttackState);
            }
            else if(isPlayerinMaxAgroRange && !performCloseRangeAction)
            {
                stateMachine.ChangeState(archer.rangedAttackState);
            }
            else if(!isPlayerinMaxAgroRange)
            {
                stateMachine.ChangeState(archer.lookForPlayerState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
