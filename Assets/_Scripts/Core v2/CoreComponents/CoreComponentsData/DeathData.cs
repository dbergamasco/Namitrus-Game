using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class DeathData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(Death);
        }

        [field: 
            Header("Dependecies: ParticleManager, HealthSystem"),
            Tooltip("Array for Blood and DeathChunk Particles"),
            SerializeField
            ] public GameObject[] deathParticles;
    }
}
