using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitBox>
    {

        public event Action<Collider2D[]> OnDetectedCollider2D;

        private Movements Movement { get => movement ??= Core?.GetCoreComponent<Movements>(); }
        private Movements movement;

        private Vector2 offset;
        private Collider2D[] detected;

        private void HandleAttackAction()
        {
            offset.Set(
                transform.position.x + (currentAttackData.HitBox.center.x * Movement.FacingDirection),
                transform.position.y + currentAttackData.HitBox.center.y
            );
            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);

            if(detected.Length == 0)
                return;
            
            OnDetectedCollider2D?.Invoke(detected);
        }

        protected override void Start()
        {
            base.Start();

            eventHandler.OnAttackAction += HandleAttackAction;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            eventHandler.OnAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected() 
        {
            if(data == null)
                return;
            
            foreach(var item in data.AttackData)
            {
                if(!item.Debug)
                    continue;

                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        
        }


    }
}