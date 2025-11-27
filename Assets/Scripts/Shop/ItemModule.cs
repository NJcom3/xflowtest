using System;
using Core;
using Core.Events;
using Shop.Components;
using Shop.Models;
using Shop.Scriptables;
using UnityEngine.SceneManagement;
using Zenject;

namespace Shop
{
    public class ItemModule
    {
        private PlayerData _playerData;
        private ShopScriptable _shopScriptable;
        private ShopItemFactory _shopItemFactory;
        private ShopItem _shopItem;

        private ShopItemModel _model;

        private bool _actionAllowed = true;
        
        [Inject]
        public void Construct(
            DiContainer diContainer,
            ShopScriptable shopScriptable,
            PlayerData playerData,
            ShopItem shopItem,
            ShopItemFactory shopItemFactory,
            EventBus eventBus
        )
        {
            _playerData = playerData;
            _shopItemFactory = shopItemFactory;
            _shopScriptable = shopScriptable;
            _shopItem = shopItem;
            
            CreateSelectedItemModel();
            eventBus.Subscribe<ActionAllowance>(AllowAction);
        }
        public void Init()
        {
            _shopItem.Init(_model);
        }

        private void CreateSelectedItemModel()
        {
            foreach (var itemScriptable in _shopScriptable.items)
            {
                if (itemScriptable.itemName == _playerData.SelectedItem())
                {
                    _model = _shopItemFactory.CreateShopItem(itemScriptable);
                    return;
                }
            }

            throw new Exception("item does not found");
        }

        public void GoToMainScene()
        {
            if (!_actionAllowed)
            {
                return;
            }
            
            SceneManager.LoadScene("ShopScene");
        }
        
        private void AllowAction(bool value)
        {
            _actionAllowed = value;
        }
    }
}