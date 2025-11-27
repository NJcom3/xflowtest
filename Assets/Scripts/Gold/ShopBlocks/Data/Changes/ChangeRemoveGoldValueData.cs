using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gold.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeRemoveGoldValueData : IChangeData
    {
        public int GoldCount;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            GoldCount = EditorGUILayout.IntField("Gold Count to Remove", GoldCount);
        }
#endif
    }
}