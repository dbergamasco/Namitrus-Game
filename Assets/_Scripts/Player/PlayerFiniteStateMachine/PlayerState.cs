using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;

public class PlayerState
{
    protected Core core;

    private WeaponHolder WeaponHolder;

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
  
        core = player.Core;
    }

    public virtual void Enter()
    {
        DoCheck();
        player.Anim.SetBool(animBoolName, true);
        // Logging for tests
        //Debug.Log(animBoolName);
        startTime = Time.time;
        
        isAnimationFinished = false;
        isExitingState = false;

        WeaponHolder = core.GetCoreComponent<WeaponHolder>();

        player.InputHandler.PreviousWeaponRequest += HandlePreviousWeapon;
        player.InputHandler.NextWeaponRequest += HandleNextWeapon;
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;

        player.InputHandler.PreviousWeaponRequest -= HandlePreviousWeapon;
        player.InputHandler.NextWeaponRequest -= HandleNextWeapon;
    }

    public virtual void LogicUpdate(){}

    public virtual void PhysicsUpdate(){
        DoCheck();
    }

    public virtual void DoCheck(){}
    public virtual void AnimationTrigger(){}
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    private void HandleNextWeapon() => WeaponHolder.NextWeapon();

    private void HandlePreviousWeapon() => WeaponHolder.PreviousWeapon();
}
