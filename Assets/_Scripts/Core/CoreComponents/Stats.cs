using System;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;

        [SerializeField] private float maxHealth;
        private float currentHealth;

        protected override void Awake()
        {
            base.Awake();

            currentHealth = maxHealth;
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                OnHealthZero?.Invoke();
            }
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }
    }
}