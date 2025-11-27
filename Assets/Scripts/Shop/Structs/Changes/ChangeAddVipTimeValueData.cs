using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddVipTimeValueData : IChangeData
    {
        public int VipHours;
        public int VipMinutes;
        public int VipSeconds;
    }
}