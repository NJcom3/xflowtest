using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddGoldValueData : IChangeData
    {
        public int GoldCount;
    }
}