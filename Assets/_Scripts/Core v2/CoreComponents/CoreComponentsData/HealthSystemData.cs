using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class HealthSystemData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(HealthSystem);
        }

        [field: SerializeField, Tooltip("Base health of the entity")] public float MaxHealth;
        [field: SerializeField, Tooltip("Base health regen per second of the entity")] public float HealthRegen;
    }
}
