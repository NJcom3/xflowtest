using System;
using System.Collections.Generic;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementNotAllowedLocationData : IRequirementData
    {
        public List<string> NotAllowedLocationList;
    }
}