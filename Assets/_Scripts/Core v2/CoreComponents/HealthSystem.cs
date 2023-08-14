using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class HealthSystem : CoreComponents<HealthSystemData>
    {
        public event Action<float> OnCurrentValueChange;

        public event Action OnCurrentValueZero;

        private float currentHeath;

        public float CurrentHealth
        {
            get => currentHeath;
            private set
            {
                currentHeath = Mathf.Clamp(value, 0f, data.MaxHealth);
                OnCurrentValueChange?.Invoke(currentHeath);

                if (currentHeath <= 0f)
                {
                OnCurrentValueZero?.Invoke();
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            CurrentHealth = data.MaxHealth;
        }

        protected override void Update()
        {
            base.Update();

            Increase(data.HealthRegen * Time.deltaTime);
        }

        public void Increase(float amount) => CurrentHealth += amount;
        public void Decrease(float amount) => CurrentHealth -= amount;
    }
}
