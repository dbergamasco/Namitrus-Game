using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class Movement : WeaponComponent<MovementData>
    {
        private CoreSystem.Movement coreMovement;
        private CoreSystem.Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

        private void HandleStartMovement()
        {
            var currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
        }

        private void HandleStopMovement()
        {
            CoreMovement.SetVelocityZero();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            eventHandler.OnStartMovement += HandleStartMovement;
            eventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            eventHandler.OnStartMovement -= HandleStartMovement;
            eventHandler.OnStopMovement -= HandleStopMovement;
        }
    }
}