using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class StatBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxValue(float maxValue)
        {
            slider.maxValue = maxValue;
            slider.value = maxValue;
        }

        public void SetValue(float value) => slider.value = value ;


    }
}
