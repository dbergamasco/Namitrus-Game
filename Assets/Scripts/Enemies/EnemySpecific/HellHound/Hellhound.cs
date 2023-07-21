using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellhound : Entity
{
    public Hellhound_idleState idleState { get; private set; }
    public HellHound_moveState moveState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;

    public override void Start()
    {
        base.Start();
        
        moveState = new HellHound_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Hellhound_idleState(this, stateMachine, "idle", idleStateData, this);
        
        stateMachine.Initialize(idleState);
    }

}
