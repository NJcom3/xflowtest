using System;
using System.Collections.Generic;
using Core.Interfaces.Shop;
using Shop.Scriptables;
using Zenject;

namespace Shop.Models
{
    public class ShopItemFactory
    {
        private DiContainer _diContainer;
        private IRequirementsFactory[] _requirementsFactories;
        private IChangeFactory[] _changeFactories;

        [Inject]
        public void Construct(
            DiContainer diContainer,
            IRequirementsFactory[] requirementsFactories,
            IChangeFactory[] changeFactories
        )
        {
            _diContainer = diContainer;
            _requirementsFactories = requirementsFactories;
            _changeFactories = changeFactories;
        }

        public ShopItemModel CreateShopItem(ShopItemScriptable shopItemScriptable, int index)
        {
            var model = new ShopItemModel(
                shopItemScriptable.itemName,
                CreateChanges(shopItemScriptable),
                CreateRequirements(shopItemScriptable),
                index
            );
            _diContainer.Inject(model);
            return model;
        }

        private List<IRequirement> CreateRequirements(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IRequirement>();
            foreach (var requirementData in shopItemScriptable.Requirements)
            {
                var requirement = CreateRequirement(requirementData);

                if (requirement == null)
                {
                    continue;
                }
                
                _diContainer.Inject(requirement);
                list.Add(requirement);
            }

            return list;
        }
        private IRequirement CreateRequirement(IRequirementData requirementData)
        {
            foreach (var factory in _requirementsFactories)
            {
                var requirement = factory.CreateRequirement(requirementData);
                if (requirement != null)
                {
                    return requirement;
                }
            }

            throw new Exception("Cant create such requirement");
        }

        private List<IChange> CreateChanges(ShopItemScriptable shopItemScriptable)
        {
            var list = new List<IChange>();
            foreach (var changeData in shopItemScriptable.Changes)
            {
                var change = CreateChange(changeData);

                if (change == null)
                {
                    continue;
                }
                
                _diContainer.Inject(change);
                list.Add(change);
            }

            return list;
        }

        private IChange CreateChange(IChangeData changeData)
        {
            foreach (var factory in _changeFactories)
            {
                var change = factory.CreateChange(changeData);
                if (change != null)
                {
                    return change;
                }
            }

            throw new Exception("Cant create such requirement");
        }
    }
}