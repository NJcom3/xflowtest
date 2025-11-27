using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddGoldPercentData : IChangeData
    {
        public int GoldPercent;
    }
}