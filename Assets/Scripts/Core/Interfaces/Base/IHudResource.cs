using System;
using UnityEngine;

namespace Core.Interfaces.Base
{
    public interface IHudResource
    {
        public void OnCheatButtonClick();
        public string GetHudValue();
    }
}