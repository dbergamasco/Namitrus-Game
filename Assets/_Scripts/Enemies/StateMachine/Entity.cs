using _Scripts.CoreSystem;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Movements Movement { get => movement ??= Core.GetCoreComponent<Movements>(); }
    private Movements movement;

    protected PlayerDetector PlayerDetector { get => playerDetector ??= Core.GetCoreComponent<PlayerDetector>(); }
    private PlayerDetector playerDetector;

    public Core Core { get; private set; }

    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public Animator anim { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }

    public int lastDamageDirection { get; private set; }

    private float currentStunResistance;
    private float lastDamageTime;

    

    private Vector2 velocityWorkspace;

    protected bool isStunned;
    protected bool isDead;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        currentStunResistance = entityData.stunResistance;

        anim = GetComponent<Animator>();
        atsm = GetComponent<AnimationToStateMachine>();

        stateMachine = new FiniteStateMachine();
    }


    public virtual void Update()
    {
        Core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();

        if(Time.time >= lastDamageTime + entityData.stunRecoveryTime)
        {
            ResetStunResist();
        }
    }

    public virtual void FixedUpdate() 
    {
        stateMachine.currentState.PhysicsUpdate();

        anim.SetFloat("yVelocity", Movement.RB.velocity.y);;
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return PlayerDetector.hasCloseRangedDetected();
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return PlayerDetector.hasLongRangedDetected();
    }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(Movement.RB.velocity.x, velocity);
        Movement.RB.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResist()
    {
        isStunned = false;
        currentStunResistance = entityData.stunResistance;
    }


}
