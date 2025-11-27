using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Vip.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMaxVipTimeData : IRequirementData
    {
        public int MaxVipHours;
        public int MaxVipMinutes;
        public int MaxVipSeconds;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MaxVipHours = EditorGUILayout.IntField("Max Hours", MaxVipHours);
            MaxVipMinutes = EditorGUILayout.IntField("Max Minutes", MaxVipMinutes);
            MaxVipSeconds = EditorGUILayout.IntField("Max Seconds", MaxVipSeconds);
        }
#endif
    }
}