using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public abstract class CoreComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public Type ComponentDependency { get; protected set; }
        
        public CoreComponentData()
        {
            SetCoreComponentName();
            SetCoreComponentDependecy();
        }

        public void SetCoreComponentName() => name = GetType().Name;

        protected abstract void SetCoreComponentDependecy();
        
    }
}
