using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class LedgeCheckData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(LedgeCheck);
        }

        public bool Debug;

        [field: SerializeField, Tooltip("True for Vertical Check, false for Horizontal")] public bool isVertical;
        [field: SerializeField, Tooltip("Range position")] public Vector2 rangePosition;
        [field: SerializeField] public Vector2 rangeRadius;
        [field: SerializeField, Tooltip("Distance to draw a line between range position and ground")] public float distance;
        [field: SerializeField, Tooltip("Your ground layerMask")] public LayerMask detectionLayer;

    }
}
