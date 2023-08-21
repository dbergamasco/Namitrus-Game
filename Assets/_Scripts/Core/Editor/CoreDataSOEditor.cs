using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor.Callbacks;

namespace _Scripts.CoreSystem
{
    [CustomEditor(typeof(CoreDataSO))]
    public class CoreDataSOEditor : Editor
    {
        private static List<Type> dataCompTypes = new List<Type>();

        

        private CoreDataSO dataSO;

        private bool showAddCoreComponentButtons;

        private void OnEnable()
        {
            dataSO = target as CoreDataSO; 
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            showAddCoreComponentButtons = EditorGUILayout.Foldout(showAddCoreComponentButtons, "Add Core Components");

            if(showAddCoreComponentButtons)
            {
                foreach(var dataCompType in dataCompTypes)
                {
                    if(GUILayout.Button(dataCompType.Name))
                    {
                        var comp = Activator.CreateInstance(dataCompType) as CoreComponentData;

                        if(comp == null)
                            return;

                        dataSO.AddData(comp);

                        EditorUtility.SetDirty(dataSO);
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
                type => type.IsSubclassOf(typeof(CoreComponentData)) && 
                !type.ContainsGenericParameters 
                && type.IsClass
                );
            dataCompTypes = filteredTypes.ToList();
      
        }
    }
}
