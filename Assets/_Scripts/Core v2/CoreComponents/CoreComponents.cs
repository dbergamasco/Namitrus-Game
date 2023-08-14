using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public abstract class CoreComponents : MonoBehaviour
    {
        protected Core core;

        public virtual void Init(Core core)
        {
            this.core = core;
        }

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void Update() { }

        public virtual void LogicUpdate() { }
        
    }

    public abstract class CoreComponents<T> : CoreComponents where T : CoreComponentData
    {
        protected T data;

        public override void Init(Core core)
        {
            base.Init(core);

            data = core.Data.GetData<T>();
        }
    }
}
