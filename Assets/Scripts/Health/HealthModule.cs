using Core;
using Core.Interfaces;
using Core.Interfaces.Domains;
using Gold.ShopBlocks;

namespace Health
{
    public class HealthModule : ABasePlayerResourceModule, IHealthModule
    {
        private int _count = 100;

        public HealthModule()
        {
            _requirementsFactory = new RequirementFactory();
            _changeFactory = new ChangeFactory();
        }

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

        
        #region [HUD]
        
        public string GetHudLabel()
        {
            return "Health: ";
        }
        public void OnCheatButtonClick()
        {
            Receive(25);
        }

        public string GetHudValue()
        {
            return GetCount().ToString();
        }
        
        #endregion
    }
}