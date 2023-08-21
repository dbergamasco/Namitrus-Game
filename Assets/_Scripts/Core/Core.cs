using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class Core : MonoBehaviour
    {
        private readonly List<CoreComponents> CoreComponents = new List<CoreComponents>();

        public CoreDataSO Data { get; private set; }

        public void SetData(CoreDataSO data)
        {
            Data = data;
        }

        private void Awake()
        {
            var comps = GetComponents<CoreComponents>();

            foreach (var component in comps)
            {
                AddComponent(component);
            }

            foreach (var component in CoreComponents)
            {
                component.Init(this);
            }
        }

        public void LogicUpdate()
        {
            var comps = GetComponents<CoreComponents>();
            foreach (var component in comps)
            {
                component.LogicUpdate();
            }
        }

        public T GetCoreComponent<T>() where T : CoreComponents
        {
            var comp = GetComponentInChildren<T>();
            if (comp == null)
            {
                Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name} at {transform.name} Object");
            }
            return comp;
        }

        public T GetCoreComponent<T>(ref T value) where T : CoreComponents
        {
            value = GetCoreComponent<T>();
            return value;
        }

        public void AddComponent(CoreComponents component)
        {
            if (!CoreComponents.Contains(component))
            {
                CoreComponents.Add(component);
            }
        }
    }
}
