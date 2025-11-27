#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    public static class CustomEditorTools
    {
        public static List<string> ListStringEditor(this List<string> toEdit, string label)
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
#endif