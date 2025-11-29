using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using UnityEngine;
using Zenject;
using Gold.ShopBlocks.Data.Changes;

namespace Gold.ShopBlocks.Models.Changes
{
    public class ChangeAddGoldPercent : IChange
    { 
        private GoldModule _goldModule;
        private readonly int _goldPercentToAdd;
        
        [Inject]
        public void Construct([InjectOptional(Id = "Gold")] IPlayerResourceModule playerResourceModule)
        {
            _goldModule = (GoldModule) playerResourceModule;
        }

        public ChangeAddGoldPercent(IChangeData data)
        {
            if (data is not ChangeAddGoldPercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _goldPercentToAdd = requiredData.GoldPercent;
        }
        
        public void Apply()
        {
            var toAdd = (int) Mathf.Ceil(_goldModule.GetCount() * (_goldPercentToAdd * 0.01f));
            _goldModule.Receive(toAdd);
        }
        
    }
}