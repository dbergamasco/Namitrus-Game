using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_MeleeAttackState : MeleeAttackState
{
    private Archer archer;

    public Archer_MeleeAttackState(Entity entity,
                                   FiniteStateMachine stateMachine,
                                   string animBoolName,
                                   D_Melee_AttackState stateData,
                                   Archer archer) : base(entity, stateMachine, animBoolName, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinish)
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(archer.playerDetectedState);
            }
            else if(!isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(archer.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
