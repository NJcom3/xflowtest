using Core.Interfaces.Domains;

namespace Health
{
    public class HealthModule : IHealthModule
    {
        private int _count = 100;

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
            Receive(25);
        }

        public string GetHudValue()
        {
            return GetCount().ToString();
        }
    }
}