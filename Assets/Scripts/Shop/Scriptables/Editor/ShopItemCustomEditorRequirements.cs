using Shop.Interfaces;
using Shop.Structs.Requirements;
using UnityEditor;
using UnityEngine;

namespace Shop.Scriptables.Editor
{
    public partial class ShopItemCustomEditor
    {
        private void DisplayRequirements(ShopItemScriptable shopItem)
        {
            EditorGUILayout.LabelField("Requirements");
            
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
                    
                    EditRequirementFields(shopItem, i);
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

        private void EditRequirementFields(ShopItemScriptable shopItem, int index)
        {
            switch (shopItem.Requirements[index])
            {
                case RequirementAllowedLocationData allowedLocationData:
                    allowedLocationData.AllowedLocationList = ListStringEditor("Allowed Locations", allowedLocationData.AllowedLocationList);
                    shopItem.Requirements[index] = allowedLocationData;
                    break;
                case RequirementNotAllowedLocationData notAllowedLocationData:
                    notAllowedLocationData.NotAllowedLocationList = ListStringEditor("Not Allowed Locations", notAllowedLocationData.NotAllowedLocationList);
                    shopItem.Requirements[index] = notAllowedLocationData;
                    break;
                case RequirementMaxGoldData maxGoldData:
                    maxGoldData.MaxGoldCount = EditorGUILayout.IntField("Max Gold Count", maxGoldData.MaxGoldCount);
                    shopItem.Requirements[index] = maxGoldData;
                    break;
                case RequirementMinGoldData minGoldData:
                    minGoldData.MinGoldCount = EditorGUILayout.IntField("Min Gold Count", minGoldData.MinGoldCount);
                    shopItem.Requirements[index] = minGoldData;
                    break;
                case RequirementMaxHealthData maxHealthData:
                    maxHealthData.MaxHealthCount = EditorGUILayout.IntField("Max Health Count", maxHealthData.MaxHealthCount);
                    shopItem.Requirements[index] = maxHealthData;
                    break;
                case RequirementMinHealthData minHealthData:
                    minHealthData.MinHealthCount = EditorGUILayout.IntField("Min Health Count", minHealthData.MinHealthCount);
                    shopItem.Requirements[index] = minHealthData;
                    break;
                case RequirementMaxVipTimeData maxVipTimeData:
                    maxVipTimeData.MaxVipHours = EditorGUILayout.IntField("Hours", maxVipTimeData.MaxVipHours);
                    maxVipTimeData.MaxVipMinutes = EditorGUILayout.IntField("Minutes", maxVipTimeData.MaxVipMinutes);
                    maxVipTimeData.MaxVipSeconds = EditorGUILayout.IntField("Seconds", maxVipTimeData.MaxVipSeconds);
                    shopItem.Requirements[index] = maxVipTimeData;
                    break;
                case RequirementMinVipTimeData minVipTimeData:
                    minVipTimeData.MinVipHours = EditorGUILayout.IntField("Hours", minVipTimeData.MinVipHours);
                    minVipTimeData.MinVipMinutes = EditorGUILayout.IntField("Minutes", minVipTimeData.MinVipMinutes);
                    minVipTimeData.MinVipSeconds = EditorGUILayout.IntField("Seconds", minVipTimeData.MinVipSeconds);
                    shopItem.Requirements[index] = minVipTimeData;
                    break;
            }
        }
        
        
        private int GetRequirementTypeIndex(IRequirementData item)
        {
            return item switch
            {
                RequirementAllowedLocationData => 0,
                RequirementNotAllowedLocationData => 1,
                RequirementMaxGoldData => 2,
                RequirementMinGoldData => 3,
                RequirementMaxHealthData => 4,
                RequirementMinHealthData => 5,
                RequirementMaxVipTimeData => 6,
                RequirementMinVipTimeData => 7,
                _ => -1
            };
        }

        private string[] GetRequirementTypes()
        {
            return new []
            {
                "Allowed Location",
                "Not Allowed Location",
                "Max Gold",
                "Min Gold",
                "Max Health",
                "Min Health",
                "Max Vip Time",
                "Min Vip Time",
            };
        }
        
        private IRequirementData CreateRequirement(int typeIndex)
        {
            return typeIndex switch
            {
                0 => new RequirementAllowedLocationData(),
                1 => new RequirementNotAllowedLocationData(),
                2 => new RequirementMaxGoldData(),
                3 => new RequirementMinGoldData(),
                4 => new RequirementMaxHealthData(),
                5 => new RequirementMinHealthData(),
                6 => new RequirementMaxVipTimeData(),
                7 => new RequirementMinVipTimeData(),
                _ => null,
            };
        }
    }
}