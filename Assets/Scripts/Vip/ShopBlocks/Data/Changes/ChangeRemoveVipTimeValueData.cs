using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Vip.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeRemoveVipTimeValueData : IChangeData
    {
        public int VipHours;
        public int VipMinutes;
        public int VipSeconds;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            VipHours = EditorGUILayout.IntField("Hours to remove", VipHours);
            VipMinutes = EditorGUILayout.IntField("Minutes to remove", VipMinutes);
            VipSeconds = EditorGUILayout.IntField("Seconds to remove", VipSeconds);
        }
#endif
    }
}