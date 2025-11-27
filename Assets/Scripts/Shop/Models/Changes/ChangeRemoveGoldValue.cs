using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeRemoveGoldValue : IChange
    {
        private IGoldModule _goldModule;
        private readonly int _goldValueToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public ChangeRemoveGoldValue(int goldValue)
        {
            _goldValueToRemove = goldValue;
        }

        public void Apply()
        {
            _goldModule.Spend(_goldValueToRemove);
        }
    }
}