using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
        [SerializeField] private GameObject damageParticles;

        private CoreComp<Stats> stats;
        private CoreComp<ParticleManager> particleManager;

        public void Damage(float amount)
        {
            float finalDamage = CalcRangeDamage(amount);
            stats.Comp?.DecreaseHealth(finalDamage);
            Debug.Log($"Final damage: {finalDamage}");

            particleManager.Comp?.StartParticlesWithRandomRotation(damageParticles);
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

            stats = new CoreComp<Stats>(core);
            particleManager = new CoreComp<ParticleManager>(core);
        }

    }
}
