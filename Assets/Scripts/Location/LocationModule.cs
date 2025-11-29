using Core.Interfaces.Domains;

namespace Location
{
    public class LocationModule : IPlayerResourceModule
    {
        private string _location = StartLocation;
        private const string StartLocation = "Sen'Jin Village";
        
        public string GetLocation()
        {
            return _location;
        }

        public void SetLocation(string location)
        {
            _location = location;
        }
        
        public void SetStartLocation()
        {
            SetLocation(StartLocation);
        }

        
        #region [HUD]
        #endregion
    }
}