using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using UnityEngine;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeRemoveGoldPercent : IChange
    {
        private IGoldModule _goldModule;
        private readonly int _goldPercentToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public ChangeRemoveGoldPercent(int goldPercent)
        {
            _goldPercentToRemove = goldPercent;
        }

        public void Apply()
        {
            var toSpend = (int) Mathf.Ceil(_goldModule.GetCount() * (_goldPercentToRemove * 0.01f));
            _goldModule.Spend(toSpend);
        }
    }
}