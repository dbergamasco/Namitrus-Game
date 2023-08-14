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
        [field: SerializeField, Tooltip("LayerMast that the previously checks will detect")] public LayerMask whatIsGround;

    }
}
