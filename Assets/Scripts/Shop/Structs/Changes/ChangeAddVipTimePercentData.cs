using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddVipTimePercentData : IChangeData
    {
        public int VipTimePercent;
    }
}