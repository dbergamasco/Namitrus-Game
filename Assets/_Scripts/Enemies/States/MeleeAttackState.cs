using _Scripts.Interfaces;
using _Scripts.CoreSystem;
using UnityEngine;

public class MeleeAttackState : AttackState
{

    private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
    private Movements movement;

    private PlayerDetector PlayerDetector { get => playerDetector ??= core.GetCoreComponent<PlayerDetector>(); }
    private PlayerDetector playerDetector;

    protected D_Melee_AttackState stateData;


    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_Melee_AttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
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

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(PlayerDetector.closeRangePosition, stateData.attackRadius, stateData.whatsIsPlayer);

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
