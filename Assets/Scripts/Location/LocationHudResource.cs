using Core.Interfaces.Domains;
using Location;
using Zenject;

namespace Location
{
    public class LocationHudResource : IHudResource
    {
        private LocationModule _locationModule;

        [Inject]
        public void Construct([InjectOptional(Id = "Location")] IPlayerResourceModule playerResourceModule)
        {
            _locationModule = (LocationModule) playerResourceModule;
        }

        public string GetHudLabel()
        {
            return "Location: ";
        }
        
        public void OnCheatButtonClick()
        {
            _locationModule.SetStartLocation();
        }

        public string GetHudValue()
        {
            return _locationModule.GetLocation();
        }
    }
}