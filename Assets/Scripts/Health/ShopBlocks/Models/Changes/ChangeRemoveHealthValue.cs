using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Health.ShopBlocks.Data.Changes;

namespace Health.ShopBlocks.Models.Changes
{
    public class ChangeRemoveHealthValue : IChange
    {
        private IHealthModule _healthModule;
        private readonly int _healthValueToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();
        }
        
        public ChangeRemoveHealthValue(IChangeData data)
        {
            if (data is not ChangeAddHealthValueData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _healthValueToRemove = requiredData.HealthCount;
        }

        public void Apply()
        {
            _healthModule.Spend(_healthValueToRemove);
        }
    }
}