using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class CoreGenerator : MonoBehaviour
    {
        [SerializeField] private Core core;
        [SerializeField] private CoreDataSO data;

        

        private List<CoreComponents> componentsAlreadyOnCore = new List<CoreComponents>();
        private List<CoreComponents> componentsAddedToCore = new List<CoreComponents>();
        private List<Type> componentDependecies = new List<Type>();


        private void Start()
        {
            if(data == null)
            {
                Debug.LogWarning($"{transform.parent.name} has no Core Data!");
            }

            GenerateCoreComponent(data);

        }

        public void GenerateCoreComponent(CoreDataSO data)
        {
            core.SetData(data);

            componentsAlreadyOnCore.Clear();
            componentsAddedToCore.Clear();
            componentDependecies.Clear();

            componentsAlreadyOnCore = GetComponents<CoreComponents>().ToList();

            componentDependecies = data.GetAllDependecies();

            foreach(var dependency in componentDependecies)
            {
                if(componentsAddedToCore.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var coreComponent = componentsAlreadyOnCore.FirstOrDefault(component => component.GetType() == dependency);

                if(coreComponent == null)
                {
                    coreComponent = gameObject.AddComponent(dependency) as CoreComponents;
                }

                coreComponent.Init(core);

                componentsAddedToCore.Add(coreComponent);
            }

            var componentsToRemove = componentsAlreadyOnCore.Except(componentsAddedToCore);

            foreach(var coreComponent in componentsToRemove)
            {
                Destroy(coreComponent);
            }
        }
    }
}
