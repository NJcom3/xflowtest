using Core.Interfaces.Domains;

namespace Gold
{
    public class GoldModule : IGoldModule
    {
        private int _count = 5000;

        public bool IsEnough(int count)
        {
            return _count >= count;
        }

        public void Spend(int count)
        {
            if (!IsEnough(count))
            {
                // TODO: handle error
                return;
            }

            _count -= count;
        }

        public void Receive(int count)
        {
            _count += count;
        }

        public int GetCount()
        {
            return _count;
        }


        public void OnCheatButtonClick()
        {
            Receive(100);
        }

        public string GetHudValue()
        {
            return GetCount().ToString();
        }
    }
}