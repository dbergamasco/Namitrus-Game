using System;
using _Scripts.CoreSystem.StatsSystem;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class Stats : CoreComponent
    {
        [field: SerializeField] public Stat Health { get; private set; }
        [field: SerializeField] public Stat Poise { get; private set; }

        [SerializeField] private float poiseRecoveryRate;

        protected override void Awake()
        {
            base.Awake();

            Health.Init();
            Poise.Init();
        }

        private void Update()
        {
            if(Poise.CurrentValue.Equals(Poise.MaxValue))
                return;

            Poise.Increase(poiseRecoveryRate * Time.deltaTime);
        }
    }
}