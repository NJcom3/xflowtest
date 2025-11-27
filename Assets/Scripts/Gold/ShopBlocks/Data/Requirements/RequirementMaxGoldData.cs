using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gold.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementMaxGoldData : IRequirementData
    {
        public int MaxGoldCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            MaxGoldCount = EditorGUILayout.IntField("Max Gold Count", MaxGoldCount);
        }
#endif
    }
}