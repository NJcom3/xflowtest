using Core.Interfaces.Domains;

namespace Location
{
    public class LocationModule : ILocationModule
    {
        private const string StartLocation = "Sen'Jin Village";
        private string _location = StartLocation;
        
        public string GetLocation()
        {
            return _location;
        }

        public void SetLocation(string location)
        {
            _location = location;
        }

        public void OnCheatButtonClick()
        {
            SetLocation(StartLocation);
        }

        public string GetHudValue()
        {
            return GetLocation();
        }
    }
}