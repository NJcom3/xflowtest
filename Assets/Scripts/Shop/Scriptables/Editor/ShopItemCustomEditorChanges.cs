using Shop.Interfaces;
using Shop.Structs.Changes;
using UnityEditor;
using UnityEngine;

namespace Shop.Scriptables.Editor
{
    public partial class ShopItemCustomEditor
    {
        private void DisplayChanges(ShopItemScriptable shopItem)
        {
            EditorGUILayout.LabelField("Changes");
            
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
                    
                    EditChangeFields(shopItem, i);
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

        private void EditChangeFields(ShopItemScriptable shopItem, int index)
        {
            switch (shopItem.Changes[index])
            {
                case ChangeAddGoldPercentData addGoldPercentData:
                    addGoldPercentData.GoldPercent = EditorGUILayout.IntField("Add Gold Percent", addGoldPercentData.GoldPercent);
                    shopItem.Changes[index] = addGoldPercentData;
                    break;
                case ChangeAddGoldValueData changeAddGoldValueData:
                    changeAddGoldValueData.GoldCount = EditorGUILayout.IntField("Add Gold Value", changeAddGoldValueData.GoldCount);
                    shopItem.Changes[index] = changeAddGoldValueData;
                    break;
                case ChangeAddHealthPercentData changeAddHealthPercentData:
                    changeAddHealthPercentData.HealthPercent = EditorGUILayout.IntField("Add Health Percent", changeAddHealthPercentData.HealthPercent);
                    shopItem.Changes[index] = changeAddHealthPercentData;
                    break;
                case ChangeAddHealthValueData changeAddHealthValueData:
                    changeAddHealthValueData.HealthCount = EditorGUILayout.IntField("Add Health Percent", changeAddHealthValueData.HealthCount);
                    shopItem.Changes[index] = changeAddHealthValueData;
                    break;
                case ChangeAddVipTimePercentData changeAddVipTimePercentData:
                    changeAddVipTimePercentData.VipTimePercent = EditorGUILayout.IntField("Add Vip Time Percent", changeAddVipTimePercentData.VipTimePercent);
                    shopItem.Changes[index] = changeAddVipTimePercentData;
                    break;
                case ChangeAddVipTimeValueData changeAddVipTimeValueData:
                    changeAddVipTimeValueData.VipHours = EditorGUILayout.IntField("Hours", changeAddVipTimeValueData.VipHours);
                    changeAddVipTimeValueData.VipMinutes = EditorGUILayout.IntField("Minutes", changeAddVipTimeValueData.VipMinutes);
                    changeAddVipTimeValueData.VipSeconds = EditorGUILayout.IntField("Seconds", changeAddVipTimeValueData.VipSeconds);
                    shopItem.Changes[index] = changeAddVipTimeValueData;
                    break;
                case ChangeGoToLocationData changeGoToLocationData:
                    changeGoToLocationData.LocationName = EditorGUILayout.TextField("Go To Location", changeGoToLocationData.LocationName);
                    shopItem.Changes[index] = changeGoToLocationData;
                    break;
                case ChangeRemoveGoldPercentData changeRemoveGoldPercentData:
                    changeRemoveGoldPercentData.GoldPercent = EditorGUILayout.IntField("Remove Gold Percent", changeRemoveGoldPercentData.GoldPercent);
                    break;
                case ChangeRemoveGoldValueData changeRemoveGoldValueData:
                    changeRemoveGoldValueData.GoldCount = EditorGUILayout.IntField("Remove Gold Value", changeRemoveGoldValueData.GoldCount);
                    shopItem.Changes[index] = changeRemoveGoldValueData;
                    break;
                case ChangeRemoveHealthPercentData changeRemoveHealthPercentData:
                    changeRemoveHealthPercentData.HealthPercent = EditorGUILayout.IntField("Remove Health Percent", changeRemoveHealthPercentData.HealthPercent);
                    shopItem.Changes[index] = changeRemoveHealthPercentData;
                    break;
                case ChangeRemoveHealthValueData changeRemoveHealthValueData:
                    changeRemoveHealthValueData.HealthCount = EditorGUILayout.IntField("Remove Health Percent", changeRemoveHealthValueData.HealthCount);
                    shopItem.Changes[index] = changeRemoveHealthValueData;
                    break;
                case ChangeRemoveVipTimePercentData changeRemoveVipTimePercentData:
                    changeRemoveVipTimePercentData.VipTimePercent = EditorGUILayout.IntField("Remove Vip Time Percent", changeRemoveVipTimePercentData.VipTimePercent);
                    shopItem.Changes[index] = changeRemoveVipTimePercentData;
                    break;
                case ChangeRemoveVipTimeValueData changeRemoveVipTimeValueData:
                    changeRemoveVipTimeValueData.VipHours = EditorGUILayout.IntField("Hours", changeRemoveVipTimeValueData.VipHours);
                    changeRemoveVipTimeValueData.VipMinutes = EditorGUILayout.IntField("Minutes", changeRemoveVipTimeValueData.VipMinutes);
                    changeRemoveVipTimeValueData.VipSeconds = EditorGUILayout.IntField("Seconds", changeRemoveVipTimeValueData.VipSeconds);
                    shopItem.Changes[index] = changeRemoveVipTimeValueData;
                    break;
            }
        }
        
        
        private int GetChangeTypeIndex(IChangeData item)
        {
            return item switch
            {
                ChangeAddGoldPercentData => 0,
                ChangeAddGoldValueData => 1,
                ChangeAddHealthPercentData => 2,
                ChangeAddHealthValueData => 3,
                ChangeAddVipTimePercentData => 4,
                ChangeAddVipTimeValueData => 5,
                ChangeGoToLocationData => 6,
                ChangeRemoveGoldPercentData => 7,
                ChangeRemoveGoldValueData => 8,
                ChangeRemoveHealthPercentData => 9,
                ChangeRemoveHealthValueData => 10,
                ChangeRemoveVipTimePercentData => 11,
                ChangeRemoveVipTimeValueData => 12,
                _ => -1
            };
        }

        private string[] GetChangeTypes()
        {
            return new []
            {
                "Add Gold Percent",
                "Add Gold Value",
                "Add Health Percent",
                "Add Health Value",
                "Add Vip Time Percent",
                "Add Vip Time Value",
                "Go To Location",
                "Remove Gold Percent",
                "Remove Gold Value",
                "Remove Health Percent",
                "Remove Health Value",
                "Remove Vip Time Percent",
                "Remove Vip Time Value",
            };
        }
        
        private IChangeData CreateChange(int typeIndex)
        {
            return typeIndex switch
            {
                0 => new ChangeAddGoldPercentData(),
                1 => new ChangeAddGoldValueData(),
                2 => new ChangeAddHealthPercentData(),
                3 => new ChangeAddHealthValueData(),
                4 => new ChangeAddVipTimePercentData(),
                5 => new ChangeAddVipTimeValueData(),
                6 => new ChangeGoToLocationData(),
                7 => new ChangeRemoveGoldPercentData(),
                8 => new ChangeRemoveGoldValueData(),
                9 => new ChangeRemoveHealthPercentData(),
                10 => new ChangeRemoveHealthValueData(),
                11 => new ChangeRemoveVipTimePercentData(),
                12 => new ChangeRemoveVipTimeValueData(),
                _ => null,
            };
        }
    }
}