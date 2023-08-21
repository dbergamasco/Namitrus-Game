using System.Collections.Generic;
using _Scripts.Weapons;
using UnityEngine;

namespace _Scripts.CoreSystem
{
    public class WeaponHolder : CoreComponents<WeaponHolderData>
    {
        //TODO: Found a way to reset attackCounter when we change weapon
        private WeaponGenerator weaponGenerator;

        private int weaponHolderMax;
        private int weaponHolderIndex; 

        public List<WeaponDataSO> currentWeapons = new List<WeaponDataSO>();

        protected override void Start()
        {
            base.Start();

            weaponGenerator = transform.parent.Find("Weapon").GetComponent<WeaponGenerator>();

            if(weaponGenerator == null)
            {
                Debug.LogWarning("WeaponGenerator is null at "+ this.name);
                return;
            }
            
            weaponHolderMax = data.weaponHolderSize;

            foreach(var weapon in data.weaponsList)
            {
                AddWeapon(weapon);
            }

            if(currentWeapons.Count > 0)
            {
                weaponHolderIndex = 0;
                weaponGenerator.ChangeWeapon(currentWeapons[weaponHolderIndex]);
            }
            else
            {
                weaponGenerator.ChangeWeapon(data.defaultWeapon);
            }
        }

        private void AddWeapon(WeaponDataSO newWeapon)
        {
            if(currentWeapons.Count < weaponHolderMax)
                {
                    currentWeapons.Add(newWeapon);
                }
        }

        public void NextWeapon()
        {
            if(currentWeapons.Count > 0)
            {
                weaponHolderIndex = (weaponHolderIndex + 1 + currentWeapons.Count) % currentWeapons.Count;
                WeaponDataSO newWeapon = currentWeapons[weaponHolderIndex];
                weaponGenerator.ChangeWeapon(newWeapon);
            }
            else
            {
                weaponGenerator.ChangeWeapon(data.defaultWeapon);
            }
        }

        public void PreviousWeapon()
        {
            if(currentWeapons.Count > 0)
            {
                weaponHolderIndex = (weaponHolderIndex - 1 + currentWeapons.Count) % currentWeapons.Count;
                WeaponDataSO newWeapon = currentWeapons[weaponHolderIndex];
                weaponGenerator.ChangeWeapon(newWeapon);
            }
            else
            {
                weaponGenerator.ChangeWeapon(data.defaultWeapon);
            }
        }    
    }
}
