using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeRemoveHealthValueData : IChangeData
    {
        public int HealthCount;
    }
}