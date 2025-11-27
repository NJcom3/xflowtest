using System;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Location.ShopBlocks.Data.Changes
{
    [Serializable]
    public class ChangeGoToLocationData : IChangeData
    {
        public string LocationName;
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            LocationName = EditorGUILayout.TextField("Go To Location", LocationName);
        }
#endif
    }
}