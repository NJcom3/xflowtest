using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Events;
using Core.Interfaces.Shop;
using UnityEngine.SceneManagement;
using Zenject;

namespace Shop.Models
{
    public class ShopItemModel
    {
        public string ItemName => _itemName;
        private readonly string _itemName;
        
        private readonly List<IRequirement> _requirements;
        private readonly List<IChange> _changes;

        private PlayerData _playerData;
        private EventBus _eventBus;
        private bool _actionAllowed = true;
        
        [Inject]
        public void Construct(
            PlayerData playerData,
            EventBus eventBus
        )
        {
            _playerData = playerData;
            _eventBus = eventBus;
            _eventBus.Subscribe<ActionAllowance>(AllowAction);
        }
        public ShopItemModel(string itemName, List<IChange> changes, List<IRequirement> requirements)
        {
            _itemName = itemName;
            _changes = changes;
            _requirements = requirements;
        }

        public bool CanBeBuyed()
        {
            foreach (var requirement in _requirements)
            {
                if (!requirement.IsValid())
                {
                    return false;
                }
            }

            return true;
        }

        public async Task TryToBuy()
        {
            if (!_actionAllowed)
            {
                return;
            }
            
            _eventBus.Publish<ActionAllowance>(false);
            
            await Task.Delay(TimeSpan.FromSeconds(3f));
            
            if (!CanBeBuyed())
            {
                return;
            }
            
            foreach (var change in _changes)
            {
                change.Apply();
            }
            
            _eventBus.Publish<ActionAllowance>(true);
        }

        public void SwitchToItemScene()
        {
            if (!_actionAllowed)
            {
                return;
            }
            
            _playerData.SelectItem(_itemName);
            SceneManager.LoadScene("ItemScene");
        }

        private void AllowAction(bool value)
        {
            _actionAllowed = value;
        }
    }
}