using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Weapons.Components;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using System.Linq;

namespace _Scripts.Weapons
{
    [CustomEditor(typeof(WeaponDataSO))]
    public class WeaponDataSOEditor : Editor
    {
        private static List<Type> dataCompTypes = new List<Type>();

        private WeaponDataSO dataSO;

        private bool showForceUpdateButtons;
        private bool showAddComponentButtons;

        private void OnEnable()
        {
            dataSO = target as WeaponDataSO; 
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Set Number of Attacks"))
            {
                foreach(var item in dataSO.ComponentData)
                {
                    item.InitializeAttackData(dataSO.NumberOfAttacks);
                }
            }


            showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

            if(showAddComponentButtons)
            {
                foreach(var dataCompType in dataCompTypes)
                {
                    if(GUILayout.Button(dataCompType.Name))
                    {
                        var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                        if(comp == null)
                            return;

                        comp.InitializeAttackData(dataSO.NumberOfAttacks);

                        dataSO.AddData(comp);

                        EditorUtility.SetDirty(dataSO);
                    }
                }
            }

            showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Updates");

            if(showForceUpdateButtons)
            {
                if(GUILayout.Button("Force Update Component Names"))
                {
                    foreach(var item in dataSO.ComponentData)
                    {
                        item.SetComponentName();
                    }
                }

                if(GUILayout.Button("Force Update Attack Names"))
                {
                    foreach(var item in dataSO.ComponentData)
                    {
                        item.SetAttackDataNames();
                    }
                }
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && 
                !type.ContainsGenericParameters 
                && type.IsClass
                );
            dataCompTypes = filteredTypes.ToList();
      
        }
    }
}
