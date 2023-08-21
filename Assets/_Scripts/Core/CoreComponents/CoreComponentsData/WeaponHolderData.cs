using System;
using System.Collections.Generic;
using _Scripts.Weapons;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    [Serializable]
    public class WeaponHolderData : CoreComponentData
    {
        protected override void SetCoreComponentDependecy()
        {
            ComponentDependency = typeof(WeaponHolder);
        }

        [field: SerializeField, Tooltip("Number of weapons that the weapon holder can carry")] public int weaponHolderSize;
        [field: SerializeField, Tooltip("Deafault Weapon to equip without any weapon in the list")] public WeaponDataSO defaultWeapon;

        [Header("Test only")]
        [field: SerializeField] public List<WeaponDataSO> weaponsList;
    }
}
