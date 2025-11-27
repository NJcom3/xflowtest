using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Gold.ShopBlocks.Data.Changes;

namespace Gold.ShopBlocks.Models.Changes
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
        
        public ChangeAddGoldValue(IChangeData data)
        {
            if (data is not ChangeAddGoldValueData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _goldValueToAdd = requiredData.GoldCount;
        }

        public void Apply()
        {
            _goldModule.Receive(_goldValueToAdd);
        }
    }
}