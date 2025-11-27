using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Health.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeRemoveHealthValueData : IChangeData
    {
        public int HealthCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            HealthCount = EditorGUILayout.IntField("Health Count to Remove", HealthCount);
        }
#endif
    }
}