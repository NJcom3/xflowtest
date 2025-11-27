using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeRemoveGoldPercentData : IChangeData
    {
        public int GoldPercent;
    }
}