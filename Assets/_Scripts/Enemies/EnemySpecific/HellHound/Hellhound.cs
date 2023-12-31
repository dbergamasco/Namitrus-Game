using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound : Entity
{
    public Hellhound_idleState idleState { get; private set; }
    public HellHound_moveState moveState { get; private set; }
    public Hellhound_playedDetectedState playerDetectedState { get; private set; }
    public Hellhound_ChargeState chargeState { get; private set; }
    public Hellhound_LookForPlayerState lookForPlayerState { get; private set; }
    public Hellhound_MeeleAttackState meeleAttackState { get; private set; }
    public Hellhound_StunState stunState { get; private set; }
    public Hellhound_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_Melee_AttackState meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();
        
        moveState = new HellHound_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Hellhound_idleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Hellhound_playedDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new Hellhound_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new Hellhound_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meeleAttackState = new Hellhound_MeeleAttackState(this, stateMachine, "meleeAttack", meleeAttackStateData, this);
        stunState = new Hellhound_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new Hellhound_DeadState(this, stateMachine, "dead", deadStateData, this);

    }

    private void HandlePoiseZero()
    {
        stateMachine.ChangeState(stunState);
    }
    
    private void Start() 
    {
        stateMachine.Initialize(idleState);
    }

    private void OnDestroy()
    {
        
    }

}
