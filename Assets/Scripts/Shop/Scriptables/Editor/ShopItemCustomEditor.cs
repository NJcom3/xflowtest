using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Shop.Scriptables.Editor
{
    [CustomEditor(typeof(ShopItemScriptable))]
    public partial class ShopItemCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var shopItem = (ShopItemScriptable) target;
            shopItem.itemName = EditorGUILayout.TextField("Shop Item Name", shopItem.itemName);
            EditorGUILayout.Separator();
            DisplayRequirements(shopItem);
            EditorGUILayout.Separator();
            DisplayChanges(shopItem);
        }

        private List<string> ListStringEditor(string label, List<string> toEdit)
        {
            toEdit ??= new List<string>();
            EditorGUILayout.LabelField($"{label}:");
                
            for (var i = 0; i < toEdit.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                toEdit[i] = EditorGUILayout.TextField((i + 1).ToString(), toEdit[i]);

                if (GUILayout.Button("Remove", GUILayout.MaxWidth(70)))
                {
                    toEdit.RemoveAt(i);
                    return toEdit;
                }
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Add Location"))
            {
                toEdit.Add("");
            }

            return toEdit;
        }
    }
}