using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class Knockback : WeaponComponent<KnockbackData, AttackKnockback>
    {
        private ActionHitBox hitBox;

        private CoreSystem.Movements movement;

        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach(var item in colliders)
            {
                if(item.TryGetComponent(out IKnockbackable knockbackable))
                {
                    knockbackable.Knockback(currentAttackData.Angle, currentAttackData.Strength, movement.FacingDirection);
                }
            }
        }
        
        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            //movement = Core.GetCoreComponent<CoreSystem.Movement>();

            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }

    }
}
