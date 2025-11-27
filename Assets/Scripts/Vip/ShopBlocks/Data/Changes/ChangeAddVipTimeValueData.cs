using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Vip.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeAddVipTimeValueData : IChangeData
    {
        public int VipHours;
        public int VipMinutes;
        public int VipSeconds;
        
                
#if UNITY_EDITOR
        public void RenderEdit()
        {
            VipHours = EditorGUILayout.IntField("Hours to add", VipHours);
            VipMinutes = EditorGUILayout.IntField("Minutes to add", VipMinutes);
            VipSeconds = EditorGUILayout.IntField("Seconds to add", VipSeconds);
        }
#endif
    }
}