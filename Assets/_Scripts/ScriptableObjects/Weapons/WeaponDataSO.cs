using System.Collections;
using System.Linq;
using System.Collections.Generic;
using _Scripts.Weapons.Components.ComponentData;
using UnityEngine;

namespace _Scripts.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        [field: SerializeReference] public List<ComponentData> componentData { get; private set; }

        public T GetData<T>()
        {
            return componentData.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("Add Sprite Data")]
        private void AddSpriteData() => componentData.Add(new WeaponSpriteData());
    }
}