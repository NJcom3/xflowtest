#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Shop;
using UnityEditor;
using UnityEngine;

namespace Shop.Scriptables.Editor
{
    [CustomEditor(typeof(ShopItemScriptable))]
    public partial class ShopItemCustomEditor : UnityEditor.Editor
    {
        private Dictionary<string, Type> _requirementTypes = null;
        private Dictionary<string, Type> _changesTypes = null;
        
        public override void OnInspectorGUI()
        {
            PrepareData();
            
            var shopItem = (ShopItemScriptable) target;
            shopItem.itemName = EditorGUILayout.TextField("Shop Item Name", shopItem.itemName);
            
            GUILayout.Space(8);
            EditorGUILayout.Separator();
            GUILayout.Space(8);

            DisplayRequirements(shopItem);
            
            GUILayout.Space(8);
            EditorGUILayout.Separator();
            GUILayout.Space(8);

            DisplayChanges(shopItem);
        }

        private void PrepareData()
        {
            if (_requirementTypes != null && _changesTypes != null)
            {
                return;
            }
            
            _requirementTypes = GetImplementations<IRequirementData>();
            _changesTypes = GetImplementations<IChangeData>();
        }

        private Dictionary<string,Type> GetImplementations<T>()
        {
            var implementations = new Dictionary<string, Type>();
            var interfaceType = typeof(T);

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in allAssemblies)
            {
                var implementingTypes = assembly.GetTypes()
                    .Where(type => interfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);

                foreach (var type in implementingTypes)
                {
                    implementations.Add(type.Name, type);
                }
            }

            return implementations;
        }
    }
}
#endif