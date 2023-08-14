using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class KnockBackReceiverData : CoreComponentData
    {

        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(KnockBackReceiver);
        }

        [field: Header("Dependecies: Movement, CollisionSenses"),SerializeField, Tooltip("Max Knockback Time")] public float maxKnockbackTime;
    }
}
