using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [CreateAssetMenu(fileName = "newCoreData", menuName = "Data/Core Data/Basic Core Data", order = 0)]
    public class CoreDataSO : ScriptableObject
    {
        [field: SerializeReference] public List<CoreComponentData> CoreComponentData { get; private set; }

        public T GetData<T>()
        {
            return CoreComponentData.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependecies()
        {
            return CoreComponentData.Select(component => component.ComponentDependency).ToList();
        }

        public void AddData(CoreComponentData data)
        {
            if(CoreComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
                return;
            
            CoreComponentData.Add(data);   
        }
    }
}
