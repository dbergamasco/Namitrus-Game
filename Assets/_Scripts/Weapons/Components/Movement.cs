using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    [Serializable]
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {
        
        private Movements CoreMovement { get => coreMovement ??= Core.GetCoreComponent<Movements>(); }
        private Movements coreMovement;

        private void HandleStartMovement()
        {
            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
        }

        private void HandleStopMovement()
        {
            CoreMovement.SetVelocityZero();
        }

        protected override void Start()
        {
            base.Start();

            eventHandler.OnStartMovement += HandleStartMovement;
            eventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            eventHandler.OnStartMovement -= HandleStartMovement;
            eventHandler.OnStopMovement -= HandleStopMovement;
        }
    }
}