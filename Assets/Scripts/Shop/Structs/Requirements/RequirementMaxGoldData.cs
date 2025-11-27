using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMaxGoldData : IRequirementData
    {
        public int MaxGoldCount;
    }
}