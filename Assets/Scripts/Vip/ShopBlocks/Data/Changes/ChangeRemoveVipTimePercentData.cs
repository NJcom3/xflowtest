using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Vip.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeRemoveVipTimePercentData : IChangeData
    {
        public int VipTimePercent;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            VipTimePercent = EditorGUILayout.IntField("Vip Time Percent To Remove", VipTimePercent);
        }
#endif
    }
}