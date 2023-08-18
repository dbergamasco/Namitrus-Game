using _Scripts.Interfaces;
using _Scripts.CoreSystem;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private E_AttackPosition E_AttackPosition { get => e_AttackPosition ??= core.GetCoreComponent<E_AttackPosition>(); }
    private E_AttackPosition e_AttackPosition;

    private Vector3 attackPosition;

    protected D_Melee_AttackState stateData;


    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_Melee_AttackState stateData) : base(entity, stateMachine, animBoolName)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
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

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition, stateData.attackRadius, stateData.whatsIsPlayer);

        foreach(Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponentInChildren<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage(stateData.attackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponentInChildren<IKnockbackable>();
            if(knockbackable != null)
            {
                knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
            }
        }
    }
}
