using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Health.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMinHealthData : IRequirementData
    {
        public int MinHealthCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MinHealthCount = EditorGUILayout.IntField("Min Health Count", MinHealthCount);
        }
#endif
    }
}