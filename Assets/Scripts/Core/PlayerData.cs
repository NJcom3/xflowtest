namespace Core
{
    public class PlayerData
    {
        private string _selectedItem;
        
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