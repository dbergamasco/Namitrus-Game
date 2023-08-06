using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
        [SerializeField] private GameObject damageParticles;

        private Stats stats;
        private ParticleManager particleManager;

        public void Damage(float amount)
        {
            float finalDamage = CalcRangeDamage(amount);
            stats.Health.Decrease(finalDamage);
            Debug.Log($"Final damage: {finalDamage}");

            particleManager?.StartParticlesWithRandomRotation(damageParticles);
        }

        public float CalcRangeDamage(float damage)
        {
            //TODO: Include crit chance 
        
            float minDamage = damage * 0.7f;
            float maxDamage = damage * 1.1f;

            var finalDamage = Random.Range(minDamage, maxDamage);
            return Mathf.Round(finalDamage);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
            particleManager = core.GetCoreComponent<ParticleManager>();
        }

    }
}
