using Core;
using Core.Interfaces.Domains;
using Gold.ShopBlocks;

namespace Location
{
    public class LocationModule : ABasePlayerResourceModule, ILocationModule
    {
        private const string StartLocation = "Sen'Jin Village";
        private string _location = StartLocation;

        public LocationModule()
        {
            _requirementsFactory = new RequirementFactory();
            _changeFactory = new ChangeFactory();
        }

        public string GetLocation()
        {
            return _location;
        }

        public void SetLocation(string location)
        {
            _location = location;
        }

        
        #region [HUD]
        public string GetHudLabel()
        {
            return "Location: ";
        }
        
        public void OnCheatButtonClick()
        {
            SetLocation(StartLocation);
        }

        public string GetHudValue()
        {
            return GetLocation();
        }
        #endregion
    }
}