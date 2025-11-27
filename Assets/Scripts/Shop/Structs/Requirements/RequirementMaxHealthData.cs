using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMaxHealthData : IRequirementData
    {
        public int MaxHealthCount;
    }
}