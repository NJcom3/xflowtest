using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gold.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMinGoldData : IRequirementData
    {
        public int MinGoldCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MinGoldCount = EditorGUILayout.IntField("Min Gold Count", MinGoldCount);
        }
#endif
    }
}