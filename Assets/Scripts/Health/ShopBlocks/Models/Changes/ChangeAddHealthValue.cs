using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Health.ShopBlocks.Data.Changes;

namespace Health.ShopBlocks.Models.Changes
{
    public class ChangeAddHealthValue : IChange
    {
        private IHealthModule _healthModule;
        private readonly int _healthValueToAdd;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();;
        }

        public ChangeAddHealthValue(IChangeData data)
        {
            if (data is not ChangeAddHealthValueData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _healthValueToAdd = requiredData.HealthCount;
        }

        public void Apply()
        {
            _healthModule.Receive(_healthValueToAdd);
        }
    }
}