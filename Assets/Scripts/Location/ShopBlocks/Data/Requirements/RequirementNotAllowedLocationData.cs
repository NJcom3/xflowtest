using System;
using System.Collections.Generic;
using Core.Interfaces.Shop;

#if UNITY_EDITOR
using Core.Editor;
#endif

namespace Location.ShopBlocks.Data.Requirements
{
    [Serializable]
    public class RequirementNotAllowedLocationData : IRequirementData
    {
        public List<string> NotAllowedLocationList;
        
        
#if UNITY_EDITOR
        public void RenderEdit()
        {
            NotAllowedLocationList = NotAllowedLocationList.ListStringEditor("Not Allowed Locations");
        }
#endif
    }
}