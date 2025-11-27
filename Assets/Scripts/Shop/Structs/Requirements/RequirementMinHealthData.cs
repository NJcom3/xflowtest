using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMinHealthData : IRequirementData
    {
        public int MinHealthCount;
    }
}