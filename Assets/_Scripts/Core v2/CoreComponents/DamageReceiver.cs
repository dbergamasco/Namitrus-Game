using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class DamageReceiver : CoreComponents<DamageReceiverData>, IDamageable
    {
        private ParticleManager ParticleManager { get => particleManager ??= core.GetCoreComponent<ParticleManager>(); }
        private ParticleManager particleManager;

        private HealthSystem HealthSystem { get => healthSystem ??= core.GetCoreComponent<HealthSystem>(); }
        private HealthSystem healthSystem;

        public float CalcRangeDamage(float damage)
        {
            //TODO: Include crit chance 
        
            float minDamage = damage * 0.7f;
            float maxDamage = damage * 1.1f;

            var finalDamage = Random.Range(minDamage, maxDamage);
            return Mathf.Round(finalDamage);
        }

        public void Damage(float damage)
        {
            float finalDamage = CalcRangeDamage(damage);
            healthSystem.Decrease(finalDamage);
            
            Debug.Log($"Final damage: {finalDamage}, CurrentHealth: {healthSystem.CurrentHealth}");
    
            particleManager?.StartParticlesWithRandomRotation(data.damageParticles);
        }
    }
}
