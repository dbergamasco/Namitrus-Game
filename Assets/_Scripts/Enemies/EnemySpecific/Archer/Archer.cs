using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Entity
{
    public Archer_MoveState moveState { get; private set; }
    public Archer_IdleState idleState { get; private set; }
    public Archer_PlayerDetectedState playerDetectedState { get; private set; }
    public Archer_MeleeAttackState meleeAttackState { get; private set; }
    public Archer_LookForPlayerState lookForPlayerState { get; private set; }
    public Archer_StunState stunState { get; private set; }
    public Archer_DeadState deadState { get; private set; }
    public Archer_DodgeState dodgeState { get; private set; }
    public Archer_RollingState rollingState { get; private set; }
    
    public Archer_RangedAttackState rangedAttackState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField]
    private D_Melee_AttackState meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    public D_RollingState rollingStateData;
    [SerializeField]
    public D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;



    public override void Awake()
    {
        base.Awake();

        moveState = new Archer_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Archer_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Archer_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new Archer_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new Archer_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new Archer_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new Archer_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new Archer_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rollingState = new Archer_RollingState(this, stateMachine, "rolling", rollingStateData, this);  
        
        rangedAttackState = new Archer_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        
    }

    private void HandlePoiseZero()
    {
        stateMachine.ChangeState(stunState);
    }
    private void Start() 
    {
        stateMachine.Initialize(moveState);

        
    }

    private void OnDestroy()
    {
        
    }

}
