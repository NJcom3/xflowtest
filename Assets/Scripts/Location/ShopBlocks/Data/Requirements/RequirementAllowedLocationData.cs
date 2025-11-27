using System;
using System.Collections.Generic;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using Core.Editor;
#endif

namespace Location.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementAllowedLocationData : IRequirementData
    {
        public List<string> AllowedLocationList;
        
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            AllowedLocationList = AllowedLocationList.ListStringEditor("Allowed Locations");
        }
#endif
    }
}