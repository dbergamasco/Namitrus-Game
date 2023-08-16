using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class KnockBackReceiver : CoreComponents<KnockBackReceiverData>, IKnockbackable
    {
        private bool isKnockbackActive;
        private float knockbackStartTime;

        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }
        private CollisionSenses collisionSenses;

        public override void LogicUpdate()
        {
            CheckKnockback();
        }


        public void Knockback(Vector2 angle, float strength, int direction)
        {
            Movement.SetVelocity(strength, angle, direction);
            Movement.CanSetVelocity = false;
            isKnockbackActive = true;
            knockbackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (isKnockbackActive && (Movement.CurrentVelocity.y <= 0.01f && CollisionSenses.isGrounded || Time.time >= knockbackStartTime + data.maxKnockbackTime))
            {
                isKnockbackActive = false;
                movement.CanSetVelocity = true;
            }
        }
    }
}
