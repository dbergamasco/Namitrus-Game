using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;

public class RangedAttackState : AttackState
{
    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private E_AttackPosition E_AttackPosition { get => e_AttackPosition ??= core.GetCoreComponent<E_AttackPosition>(); }
    private E_AttackPosition e_AttackPosition;

    public D_RangedAttackState stateData;

    protected GameObject projectile;
    protected Projectile projectileScript;

    private Vector3 attackPosition;

    public RangedAttackState(Entity entity,
                             FiniteStateMachine stateMachine,
                             string animBoolName,
                             D_RangedAttackState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        attackPosition = E_AttackPosition.MelleeAttackPosition;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        projectile = GameObject.Instantiate(stateData.projectile, attackPosition,  entity.transform.rotation);
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage, stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
