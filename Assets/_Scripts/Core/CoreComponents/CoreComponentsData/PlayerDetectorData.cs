using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class PlayerDetectorData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(PlayerDetector);
        }

        public bool Debug;

        [Header("Close Range Detector")]
        [field: SerializeField, Tooltip("Close range position")] public Vector2 closeRangePos;
        [field: SerializeField] public Vector2 closeRangeRadius;


        [Header("Long Range Detector")]
        [field: SerializeField, Tooltip("Long range position")] public Vector2 longRangePos;
        [field: SerializeField] public Vector2 longRangeRadius;

        [field: SerializeField, Tooltip("Your ground layerMask")] public LayerMask detectionLayer;

    }
}
