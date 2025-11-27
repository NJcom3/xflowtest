using System;
using Shop.Interfaces;

namespace Shop.Structs.Requirements
{
    [Serializable]
    public struct RequirementMinVipTimeData : IRequirementData
    {
        public int MinVipHours;
        public int MinVipMinutes;
        public int MinVipSeconds;
    }
}