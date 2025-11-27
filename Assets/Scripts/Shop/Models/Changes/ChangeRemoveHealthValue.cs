using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
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

        public ChangeRemoveHealthValue(int healthValue)
        {
            _healthValueToRemove = healthValue;
        }

        public void Apply()
        {
            _healthModule.Spend(_healthValueToRemove);
        }
    }
}