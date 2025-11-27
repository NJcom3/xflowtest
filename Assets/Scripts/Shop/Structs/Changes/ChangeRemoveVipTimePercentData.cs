using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeRemoveVipTimePercentData : IChangeData
    {
        public int VipTimePercent;
    }
}