using System;
using Shop.Interfaces;

namespace Shop.Structs.Changes
{
    [Serializable]
    public struct ChangeGoToLocationData : IChangeData
    {
        public string LocationName;
    }
}