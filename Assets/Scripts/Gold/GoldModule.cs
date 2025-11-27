using Core;
using Core.Interfaces.Domains;
using Gold.ShopBlocks;

namespace Gold
{
    public class GoldModule : ABasePlayerResourceModule, IGoldModule
    {
        private int _count = 5000;

        public GoldModule()
        {
            _changeFactory = new ChangeFactory();
            _requirementsFactory = new RequirementFactory();
        }

        public bool IsEnough(int count)
        {
            return _count >= count;
        }

        public void Spend(int count)
        {
            if (!IsEnough(count))
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
        
        #region [HUD]
        
        public string GetHudLabel()
        {
            return "Gold: ";
        }
        
        public void OnCheatButtonClick()
        {
            Receive(100);
        }

        public string GetHudValue()
        {
            return GetCount().ToString();
        }

        
        #endregion
    }
}