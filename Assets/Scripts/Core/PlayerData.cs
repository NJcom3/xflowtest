using System;
using System.Collections.Generic;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;

namespace Core
{
    public class PlayerData
    {
        private IPlayerResourceModule[] _resourceModules;
        private string _selectedItem;
        
        [Inject]
        public void Construct(IPlayerResourceModule[] resourceModules)
        {
            _resourceModules = resourceModules;
        }

        public T GetModule<T>() where T : IPlayerResourceModule
        {
            foreach (var playerResourceModule in _resourceModules)
            {
                if (playerResourceModule is T lookingResourceModule)
                {
                    return lookingResourceModule;
                }
            }

            throw new Exception("Module not found");
        }

        public List<IHudResource> GetHudResources()
        {
            var list = new List<IHudResource>();
            
            foreach (var model in _resourceModules)
            {
                if (model is not IHudResource hudResource)
                {
                    continue;
                } 
                
                list.Add(hudResource);
            }

            return list;
        }

        public IRequirement CreateRequirement(IRequirementData requirementData)
        {
            foreach (var module in _resourceModules)
            {
                var requirement = module.CreateRequirement(requirementData);
                if (requirement != null)
                {
                    return requirement;
                }
            }

            throw new Exception("Cant create such requirement");
        }

        public IChange CreateChange(IChangeData changeData)
        {
            foreach (var module in _resourceModules)
            {
                var change = module.CreateChange(changeData);
                if (change != null)
                {
                    return change;
                }
            }

            throw new Exception("Cant create such requirement");
        }
        
        public void SelectItem(string itemName)
        {
            _selectedItem = itemName;
        }

        public string SelectedItem()
        {
            return _selectedItem;
        }
    }
}