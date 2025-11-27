using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeRemoveGoldValueData : IChangeData
    {
        public int GoldCount;
    }
}