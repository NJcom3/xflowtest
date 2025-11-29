using System;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using UnityEngine;
using Zenject;
using Health.ShopBlocks.Data.Changes;

namespace Health.ShopBlocks.Models.Changes
{
    public class ChangeAddHealthPercent : IChange
    {
        private HealthModule _healthModule;
        private readonly int _healthPercentToAdd;

        [Inject]
        public void Construct([InjectOptional(Id = "Health")] IPlayerResourceModule playerResourceModule)
        {
            _healthModule = (HealthModule) playerResourceModule;
        }

        public ChangeAddHealthPercent(IChangeData data)
        {
            if (data is not ChangeAddHealthPercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _healthPercentToAdd = requiredData.HealthPercent;
        }

        public void Apply()
        {
            var toAdd = (int) Mathf.Ceil(_healthModule.GetCount() * (_healthPercentToAdd * 0.01f));
            _healthModule.Receive(toAdd);
        }
    }
}