using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Vip.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMinVipTimeData : IRequirementData
    {
        public int MinVipHours;
        public int MinVipMinutes;
        public int MinVipSeconds;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MinVipHours = EditorGUILayout.IntField("Min Hours", MinVipHours);
            MinVipMinutes = EditorGUILayout.IntField("Min Minutes", MinVipMinutes);
            MinVipSeconds = EditorGUILayout.IntField("Min Seconds", MinVipSeconds);
        }
#endif
    }
}