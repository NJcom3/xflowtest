using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
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

        public ChangeAddHealthValue(int healthValue)
        {
            _healthValueToAdd = healthValue;
        }

        public void Apply()
        {
            _healthModule.Receive(_healthValueToAdd);
        }
    }
}