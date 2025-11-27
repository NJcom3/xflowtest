using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeAddGoldValue : IChange
    {
        private IGoldModule _goldModule;
        private readonly int _goldValueToAdd;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public ChangeAddGoldValue(int goldValue)
        {
            _goldValueToAdd = goldValue;
        }

        public void Apply()
        {
            _goldModule.Receive(_goldValueToAdd);
        }
    }
}