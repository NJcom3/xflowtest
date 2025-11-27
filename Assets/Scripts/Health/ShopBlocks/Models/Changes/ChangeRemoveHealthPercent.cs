using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using UnityEngine;
using Zenject;
using Health.ShopBlocks.Data.Changes;

namespace Health.ShopBlocks.Models.Changes
{
    public class ChangeRemoveHealthPercent : IChange
    {
        private IHealthModule _healthModule;
        private readonly int _healthPercentToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();
        }
        
        public ChangeRemoveHealthPercent(IChangeData data)
        {
            if (data is not ChangeRemoveHealthPercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _healthPercentToRemove = requiredData.HealthPercent;
        }

        public void Apply()
        {
            var toSpend = (int) Mathf.Ceil(_healthModule.GetCount() * (_healthPercentToRemove * 0.01f));
            _healthModule.Spend(toSpend);
        }
    }
}