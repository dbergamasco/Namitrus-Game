using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class LedgeCheckVerticalData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(LedgeCheckVertical);
        }

        public bool Debug;

        [field: SerializeField, Tooltip("Distance between entity BoxCollider center and the ledgeCheckVerticalRadius (to detect ledges to evade fall)")] public float ledgeCheckVerticalDistance;
        [field: SerializeField, Tooltip("LayerMast that the previously checks will detect")] public LayerMask whatIsGround;
    }
}
