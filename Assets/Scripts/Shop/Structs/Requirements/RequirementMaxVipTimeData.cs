using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMaxVipTimeData : IRequirementData
    {
        public int MaxVipHours;
        public int MaxVipMinutes;
        public int MaxVipSeconds;
    }
}