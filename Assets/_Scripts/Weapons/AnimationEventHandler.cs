
using System;
using UnityEngine;

namespace _Script.Weapons
{
    public class AnimationEventHandler : MonoBehaviour
    {
        public event Action OnFinish;
        private void AnimationFinishTrigger() => OnFinish?.Invoke();
    }
}
