using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMinGoldData : IRequirementData
    {
        public int MinGoldCount;
    }
}