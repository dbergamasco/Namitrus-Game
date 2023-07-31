using System.Collections;
using System.Linq;
using System.Collections.Generic;
using _Scripts.Weapons.Components;
using UnityEngine;

namespace _Scripts.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

        public T GetData<T>()
        {
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        public void AddData(ComponentData data)
        {
            if(ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
                return;
            
            ComponentData.Add(data);   
        }
    }
}