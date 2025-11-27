#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Shop;
using UnityEditor;
using UnityEngine;

namespace Shop.Scriptables.Editor
{
    public partial class ShopItemCustomEditor
    {
        private void DisplayRequirements(ShopItemScriptable shopItem)
        {
            EditorGUILayout.LabelField("Requirements");

            if (shopItem.Requirements == null)
            {
                shopItem.Requirements = new List<IRequirementData>();
            }

            if (GUILayout.Button("Add Item"))
            {
                shopItem.Requirements.Add(null);
            }

            GUILayout.Space(8);

            for (var i = 0; i < shopItem.Requirements.Count; i++)
            {
                EditorGUILayout.BeginVertical("box");

                var itemType = EditorGUILayout.Popup(
                    "Requirement Type",
                    GetRequirementTypeIndex(shopItem.Requirements[i]),
                    GetRequirementTypes()
                );

                if (itemType != -1)
                {
                    if (itemType != GetRequirementTypeIndex(shopItem.Requirements[i]))
                    {
                        shopItem.Requirements[i] = CreateRequirement(itemType);
                    }

                    shopItem.Requirements[i].RenderEdit();
                }

                if (GUILayout.Button("Remove Item"))
                {
                    shopItem.Requirements.RemoveAt(i);
                }

                EditorGUILayout.EndVertical();
                GUILayout.Space(8);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private int GetRequirementTypeIndex(IRequirementData item)
        {
            var data = _requirementTypes.Values.ToArray();

            if (item == null)
            {
                return -1;
            }
            
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == item.GetType())
                {
                    return i;
                }
            }

            return -1;
        }

        private string[] GetRequirementTypes()
        {
            return _requirementTypes.Keys.ToArray();
        }

        private IRequirementData CreateRequirement(int typeIndex)
        {
            var data = _requirementTypes.Values.ToArray();
            return (IRequirementData) Activator.CreateInstance(data[typeIndex]);
        }
    }
}
#endif