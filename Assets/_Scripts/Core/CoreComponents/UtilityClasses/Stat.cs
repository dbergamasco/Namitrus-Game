using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class Stat
    {
        public event Action OnCurrentValueZero;

        private float currentValue;
        
        public float MaxValue { get; private set; }
        public float CurrentValue
        {
            get => currentValue;
            private set
            {
                currentValue = Mathf.Clamp(value, 0f, value);

                if(currentValue <= 0f)
                {
                    OnCurrentValueZero?.Invoke();
                }
            }
        }

        

        public Stat(float value)
        {
            this.CurrentValue = value;
        }

        public void Init(float value) => CurrentValue = value;

        public void Increase(float amount) => CurrentValue += amount;
        public void Decrease(float amount) => CurrentValue -= amount; 
    }

}
