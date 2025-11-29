using Core.Interfaces.Domains;
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