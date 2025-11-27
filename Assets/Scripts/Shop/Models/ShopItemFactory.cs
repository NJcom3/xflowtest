using System.Collections.Generic;
using Core;
using Core.Interfaces.Shop;
using Shop.Scriptables;
using Zenject;

namespace Shop.Models
{
    public class ShopItemFactory
    {
        private DiContainer _diContainer;
        private PlayerData _playerData;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            PlayerData playerData
        )
        {
            _diContainer = diContainer;
            _playerData = playerData;
        }

        public ShopItemModel CreateShopItem(ShopItemScriptable shopItemScriptable)
        {
            var model = new ShopItemModel(
                shopItemScriptable.itemName,
                GetChangesList(shopItemScriptable),
                GetRequirementsList(shopItemScriptable)
            );
            _diContainer.Inject(model);
            return model;
        }

        private List<IRequirement> GetRequirementsList(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IRequirement>();
            foreach (var requirementData in shopItemScriptable.Requirements)
            {
                var requirement = _playerData.CreateRequirement(requirementData);

                if (requirement != null)
                {
                    _diContainer.Inject(requirement);
                    list.Add(requirement);
                }
            }

            return list;
        }

        private List<IChange> GetChangesList(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IChange>();
            foreach (var changeData in shopItemScriptable.Changes)
            {
                var change = _playerData.CreateChange(changeData);

                if (change != null)
                {
                    _diContainer.Inject(change);
                    list.Add(change);
                }
            }

            return list;
        }
    }
}