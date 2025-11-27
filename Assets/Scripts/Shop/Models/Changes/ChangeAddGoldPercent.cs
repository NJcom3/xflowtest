using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using UnityEngine;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeAddGoldPercent : IChange
    { 
        private IGoldModule _goldModule;
        private readonly int _goldPercentToAdd;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public ChangeAddGoldPercent(int goldPercent)
        {
            _goldPercentToAdd = goldPercent;
        }

        public void Apply()
        {
            var toAdd = (int) Mathf.Ceil(_goldModule.GetCount() * (_goldPercentToAdd * 0.01f));
            _goldModule.Receive(toAdd);
        }
    }
}