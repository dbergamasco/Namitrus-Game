using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound_MeeleAttackState : MeleeAttackState
{
    private Hellhound hellhound;

    public Hellhound_MeeleAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_Melee_AttackState stateData, Hellhound hellhound) : base(entity, stateMachine, animBoolName, stateData)
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
               stateMachine.ChangeState(hellhound.playerDetectedState); 
            }
            else
            {
                stateMachine.ChangeState(hellhound.lookForPlayerState);
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
