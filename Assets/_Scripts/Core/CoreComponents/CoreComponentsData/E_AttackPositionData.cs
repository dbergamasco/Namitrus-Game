using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class E_AttackPositionData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(E_AttackPosition);
        }

        public bool Debug;
        
        [field: SerializeField, Tooltip("Position of the Mellee Attack")] public Vector2 melleeAttackPosition;
        [field: SerializeField] public Vector2 melleeAttackPositionRadius;

        [field: SerializeField, Tooltip("Position of the Ranged Attack")] public Vector2 rangedAttackPosition;
        [field: SerializeField] public Vector2 rangedAttackPositionRadius;
    }
}
