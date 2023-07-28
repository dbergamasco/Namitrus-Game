using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core core;

        protected virtual void Awake()
        {
            core = transform.parent.GetComponent<Core>();

            if (core == null) { Debug.LogError("There is no core in the parent!"); }
            core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}