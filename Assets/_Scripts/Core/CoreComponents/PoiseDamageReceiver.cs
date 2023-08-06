using System.Collections;
using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class PoiseDamageReceiver : CoreComponent, IPoiseDamageable
    {
        private Stats stats;

        void IPoiseDamageable.DamagePoise(float amount)
        {
            stats.Poise.Decrease(amount);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }
    }
}
