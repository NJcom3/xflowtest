using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gold.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeRemoveGoldPercentData : IChangeData
    {
        public int GoldPercent;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            GoldPercent = EditorGUILayout.IntField("Gold Percent to Remove", GoldPercent);
        }
#endif
    }
}