using System.Collections;
using System.Collections.Generic;
using _Scripts.CoreSystem;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class E_AttackPosition : CoreComponents<E_AttackPositionData>
    {
        private Movements Movement { get => movement ??= core.GetCoreComponent<Movements>(); }
        private Movements movement; 

        private Vector2 center;

        public Vector3 MelleeAttackPosition { get => melleeAttackPosition; private set => melleeAttackPosition = value; }
        private Vector3 melleeAttackPosition;

        public Vector3 RangedAttackPosition { get => rangedAttackPosition; private set => rangedAttackPosition = value; }
        private Vector3 rangedAttackPosition;

        protected override void Awake()
        {
            base.Awake();

            center = transform.position;
        }

        protected override void Update()
        {
            base.Update();

            center = transform.position;
            MelleeAttackPosition = CalculateCubePosition(center, data.melleeAttackPosition);
            RangedAttackPosition = CalculateCubePosition(center, data.rangedAttackPosition);
        }

        private Vector3 CalculateCubePosition(Vector2 center, Vector2 rangePosition)
        {
            return new Vector3(center.x + rangePosition.x * Movement.FacingDirection, center.y - rangePosition.y, 0);
        }

        private void OnDrawGizmos()
        {
            if(data.Debug)
            {
                Vector3 melleeAttackPosition = new Vector3(center.x + data.melleeAttackPosition.x * Movement.FacingDirection, center.y - data.melleeAttackPosition.y, 0);
                Vector3 melleeAttackCubeSize = new Vector3(data.melleeAttackPositionRadius.x * 2, data.melleeAttackPositionRadius.y * 2, 0);

                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(melleeAttackPosition, melleeAttackCubeSize);

                Vector3 rangedAttackPosition = new Vector3(center.x + data.rangedAttackPosition.x * Movement.FacingDirection, center.y - data.rangedAttackPosition.y, 0);
                Vector3 rangedAttackCubeSize = new Vector3(data.rangedAttackPositionRadius.x * 2, data.rangedAttackPositionRadius.y * 2, 0);

                Gizmos.color = Color.magenta;
                Gizmos.DrawWireCube(rangedAttackPosition, rangedAttackCubeSize);
            }
        }
    }
}
