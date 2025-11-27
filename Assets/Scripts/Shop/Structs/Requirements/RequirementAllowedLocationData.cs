using System;
using System.Collections.Generic;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementAllowedLocationData : IRequirementData
    {
        public List<string> AllowedLocationList;
    }
}