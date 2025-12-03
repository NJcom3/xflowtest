namespace Core
{
    public class PlayerData
    {
        private int _selectedItemIndex;
        
        public void SelectItem(int index)
        {
            _selectedItemIndex = index;
        }

        public int SelectedItemIndex()
        {
            return _selectedItemIndex;
        }
    }
}