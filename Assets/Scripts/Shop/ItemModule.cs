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
            var index = _playerData.SelectedItemIndex();

            if (index < 0 || _shopScriptable.items.Count < index - 1)
            {
                throw new Exception("item does not found");
            }
            
            _model = _shopItemFactory.CreateShopItem(_shopScriptable.items[index], index);
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