using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Gold.ShopBlocks.Data.Changes;

namespace Gold.ShopBlocks.Models.Changes
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

        public ChangeRemoveGoldValue(IChangeData data)
        {
            if (data is not ChangeRemoveGoldValueData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _goldValueToRemove = requiredData.GoldCount;
        }
        
        public void Apply()
        {
            _goldModule.Spend(_goldValueToRemove);
        }
    }
}