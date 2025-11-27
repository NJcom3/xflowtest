using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Health.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMaxHealthData : IRequirementData
    {
        public int MaxHealthCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MaxHealthCount = EditorGUILayout.IntField("Max Health Count", MaxHealthCount);
        }
#endif
    }
}