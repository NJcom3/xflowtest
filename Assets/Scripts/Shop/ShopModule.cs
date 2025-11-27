using System.Collections.Generic;
using Shop.Components;
using Shop.Models;
using Shop.Scriptables;
using UnityEngine;
using Zenject;

namespace Shop
{
    public class ShopModule
    {
        private DiContainer _diContainer;
        private ShopScriptable _shopScriptable;
        private ShopItem _shopItem;
        private ItemsContainer _itemsContainer;
        private ShopItemFactory _shopItemFactory;

        private List<ShopItemModel> _models;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            ShopScriptable shopScriptable,
            ShopItem shopItem,
            ItemsContainer itemsContainer,
            ShopItemFactory shopItemFactory
        )
        {
            _diContainer = diContainer;
            _shopScriptable = shopScriptable;
            _shopItem = shopItem;
            _itemsContainer = itemsContainer;
            _shopItemFactory = shopItemFactory;
            
            CreateModels();
        }

        private void CreateModels()
        {
            _models = new List<ShopItemModel>();
            
            foreach (var scriptable in _shopScriptable.items)
            {
                var model = _shopItemFactory.CreateShopItem(scriptable);
                _models.Add(model);
            }
        }
        
        public void RenderShop()
        {
            foreach (var model in _models)
            {
                var item = GameObject.Instantiate(_shopItem, _itemsContainer.transform);
                _diContainer.Inject(item);
                item.Init(model);
            }
        }
    }
}