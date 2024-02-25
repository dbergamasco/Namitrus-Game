using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Weapons.Components;
using UnityEngine;

namespace _Scripts.Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponDataSO data;

        private List<WeaponComponent> componentsAlreadyOnWeapon = new List<WeaponComponent>();
        private List<WeaponComponent> componentsAddedToWeapon = new List<WeaponComponent>();
        private List<Type> componentDependecies = new List<Type>();

        private Animator anim;


        private void Start()
        {
            anim = GetComponentInChildren<Animator>();

            GenerateWeapon(data,data.WeaponSpeed);
        }

        [ContextMenu("Test Generate")]
        private void TestGeneration()
        {
            GenerateWeapon(data,data.WeaponSpeed);
        }

        public void GenerateWeapon(WeaponDataSO data, float weaponSpeed)
        {
            weapon.SetData(data);

            componentsAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependecies.Clear();

            componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();

            componentDependecies = data.GetAllDependecies();

            foreach(var dependency in componentDependecies)
            {
                if(componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency))
                    continue;

                var weaponComponent = componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency);

                if(weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                weaponComponent.Init();

                componentsAddedToWeapon.Add(weaponComponent);
            }

            var componentsToRemove = componentsAlreadyOnWeapon.Except(componentsAddedToWeapon);

            foreach(var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }

            weapon.ResetAttackCounter();
            anim.runtimeAnimatorController = data.AnimatorController;
            anim.speed = weaponSpeed;
        }

        public void ChangeWeapon(WeaponDataSO newData, float weaponSpeed) => GenerateWeapon(newData, weaponSpeed);
    }
}
