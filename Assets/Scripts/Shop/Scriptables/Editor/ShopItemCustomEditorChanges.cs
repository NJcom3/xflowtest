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
        private void DisplayChanges(ShopItemScriptable shopItem)
        {
            EditorGUILayout.LabelField("Changes");

            if (shopItem.Changes == null)
            {
                shopItem.Changes = new List<IChangeData>();
            }

            if (GUILayout.Button("Add Item"))
            {
                shopItem.Changes.Add(null);
            }

            GUILayout.Space(8);

            for (var i = 0; i < shopItem.Changes.Count; i++)
            {
                EditorGUILayout.BeginVertical("box");

                var itemType = EditorGUILayout.Popup(
                    "Change Type",
                    GetChangeTypeIndex(shopItem.Changes[i]),
                    GetChangeTypes()
                );

                if (itemType != -1)
                {
                    if (itemType != GetChangeTypeIndex(shopItem.Changes[i]))
                    {
                        shopItem.Changes[i] = CreateChange(itemType);
                    }

                    shopItem.Changes[i].RenderEdit();
                }

                if (GUILayout.Button("Remove Item"))
                {
                    shopItem.Changes.RemoveAt(i);
                }

                EditorGUILayout.EndVertical();
                GUILayout.Space(8);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private int GetChangeTypeIndex(IChangeData item)
        {
            var data = _changesTypes.Values.ToArray();

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

        private string[] GetChangeTypes()
        {
            return _changesTypes.Keys.ToArray();
        }

        private IChangeData CreateChange(int typeIndex)
        {
            var data = _changesTypes.Values.ToArray();
            return (IChangeData) Activator.CreateInstance(data[typeIndex]);
        }
    }
}
#endif