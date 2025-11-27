using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeRemoveHealthPercentData : IChangeData
    {
        public int HealthPercent;
    }
}