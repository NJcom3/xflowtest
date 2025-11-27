using System;
using System.Collections.Generic;
using Core.Interfaces.Domains;
using Zenject;

namespace Core
{
    public class PlayerData
    {
        private List<IPlayerResourceModule> _resourceModules;
        private string _selectedItem;
        
        [Inject]
        public void Construct(
            IHealthModule healthModule,
            IGoldModule goldModule,
            ILocationModule locationModule,
            IVipModule vipModule
            )
        {
            _resourceModules = new List<IPlayerResourceModule>();
            
            _resourceModules.Add(healthModule);
            _resourceModules.Add(goldModule);
            _resourceModules.Add(vipModule);
            _resourceModules.Add(locationModule);
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