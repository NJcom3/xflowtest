using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeAddHealthPercentData : IChangeData
    {
        public int HealthPercent;
    }
}