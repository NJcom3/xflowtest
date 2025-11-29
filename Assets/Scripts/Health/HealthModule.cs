using Core.Interfaces.Domains;

namespace Health
{
    public class HealthModule : IPlayerResourceModule
    {
        private int _count = 100;

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