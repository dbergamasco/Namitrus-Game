using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class DamageReceiverData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(DamageReceiver);
        }
        
        [field: Header("Components Dependencies: HealthSystem, ParticleManager"), SerializeField, Tooltip("Particle to spawn when hitted")] public GameObject damageParticles; 
    }
}
