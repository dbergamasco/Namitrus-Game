using System.Collections;
using System.Linq;
using System.Collections.Generic;
using _Scripts.Weapons.Components;
using UnityEngine;
using System;

namespace _Scripts.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        //AC com a animação BASE da arma.
        [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }
        [field: SerializeField] public int NumberOfAttacks { get; private set; }
        [field: SerializeField] public float WeaponSpeed { get; private set; }
        [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

        public T GetData<T>()
        {
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependecies()
        {
            return ComponentData.Select(component => component.ComponentDependency).ToList();
        }

        public void AddData(ComponentData data)
        {
            if(ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
                return;
            
            ComponentData.Add(data);   
        }
    }
}