using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound : Entity
{
    public Hellhound_idleState idleState { get; private set; }
    public HellHound_moveState moveState { get; private set; }
    public Hellhound_playedDetectedState playerDetectedState { get; private set; }
    public Hellhound_ChargeState chargeState { get; private set; }
    public Hellhound_LookForPlayerState lookForPlayerstate { get; private set; }

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

    public override void Start()
    {
        base.Start();
        
        moveState = new HellHound_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Hellhound_idleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Hellhound_playedDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new Hellhound_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerstate = new Hellhound_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        
        stateMachine.Initialize(idleState);
    }

}
