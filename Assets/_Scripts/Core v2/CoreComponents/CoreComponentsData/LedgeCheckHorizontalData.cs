using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class LedgeCheckHorizontalData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(LedgeCheckHorizontal);
        }

        public bool Debug;

        [field: SerializeField, Tooltip("Distance between entity BoxCollider center and the ledgeCheckHorizontalRadius (to detect ledges to climb)")] public float ledgeCheckHorizontalDistance;
        [field: SerializeField, Tooltip("LayerMast that the previously checks will detect")] public LayerMask whatIsGround;

    }
}
