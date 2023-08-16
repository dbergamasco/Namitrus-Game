using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;

        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach(var item in colliders)
            {
                IDamageable damageable = item.GetComponentInChildren<IDamageable>();
                if(damageable != null)
                {
                    damageable.Damage(currentAttackData.Amount);
                }
            }
        }


        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }

    } 
}
