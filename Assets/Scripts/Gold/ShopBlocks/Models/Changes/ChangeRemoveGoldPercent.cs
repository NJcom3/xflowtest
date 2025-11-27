using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using UnityEngine;
using Zenject;
using Gold.ShopBlocks.Data.Changes;


namespace Gold.ShopBlocks.Models.Changes
{
    public class ChangeRemoveGoldPercent : IChange
    {
        private IGoldModule _goldModule;
        private readonly int _goldPercentToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }
        
        public ChangeRemoveGoldPercent(IChangeData data)
        {
            if (data is not ChangeRemoveGoldPercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _goldPercentToRemove = requiredData.GoldPercent;
        }

        public void Apply()
        {
            var toSpend = (int) Mathf.Ceil(_goldModule.GetCount() * (_goldPercentToRemove * 0.01f));
            _goldModule.Spend(toSpend);
        }
    }
}