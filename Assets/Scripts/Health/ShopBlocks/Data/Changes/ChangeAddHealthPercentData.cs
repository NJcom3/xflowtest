using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Health.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeAddHealthPercentData : IChangeData
    {
        public int HealthPercent;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            HealthPercent = EditorGUILayout.IntField("Health Percent to Add", HealthPercent);
        }
#endif
    }
}