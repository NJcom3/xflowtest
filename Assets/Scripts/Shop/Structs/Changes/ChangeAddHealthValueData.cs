using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddHealthValueData : IChangeData
    {
        public int HealthCount;
    }
}