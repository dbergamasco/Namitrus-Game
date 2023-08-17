using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class CollisionSensesData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(CollisionSenses);
        }

        public bool Debug;

        [field: SerializeField, Tooltip("Ground Check position")] public Vector2 groundCheckPosition;
        [field: SerializeField] public Vector2 groundCheckRadius;
        [field: SerializeField, Tooltip("Distance to raycast a line between ground check position and ground to detect")] public float groundCheckDistance;

        [field: SerializeField, Tooltip("Ground Check position")] public Vector2 wallCheckPosition;
        [field: SerializeField] public Vector2 wallCheckRadius;
        [field: SerializeField, Tooltip("Distance to raycast a line between wall check position and wall to detect")] public float wallCheckDistance;

        [field: SerializeField, Tooltip("LayerMast that the previously checks will detect")] public LayerMask whatIsGround;

    }
}
