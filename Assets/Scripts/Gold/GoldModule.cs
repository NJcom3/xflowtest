using Core.Interfaces.Domains;

namespace Gold
{
    public class GoldModule : IPlayerResourceModule
    {
        private int _count = 5000;

        public void Spend(int count)
        {
            if (_count >= count)
            {
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
    }
}