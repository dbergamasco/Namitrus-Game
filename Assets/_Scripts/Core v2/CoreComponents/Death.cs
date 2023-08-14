using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class Death : CoreComponents<DeathData>
    {
        private ParticleManager ParticleManager { get => particleManager ??= core.GetCoreComponent<ParticleManager>(); }
        private ParticleManager particleManager;

        private HealthSystem HealthSystem { get => healthSystem ??= core.GetCoreComponent<HealthSystem>(); }
        private HealthSystem healthSystem;

        public void Die()
        {
            {
                foreach (var particle in data.deathParticles)
                {
                    ParticleManager.StartParticles(particle);
                }

                core.transform.parent.gameObject.SetActive(false);
            }
        }

        protected override void Start()
        {
            base.Start();

            HealthSystem.OnCurrentValueZero += Die;
        }

        private void OnDestroy()
        {
            HealthSystem.OnCurrentValueZero -= Die;
        }
    }
}
