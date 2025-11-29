using System;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Location.ShopBlocks.Data.Changes;

namespace Location.ShopBlocks.Models.Changes
{
    public class ChangeGoToLocation : IChange
    {
        private LocationModule _locationModule;
        private readonly string _location;

        [Inject]
        public void Construct([InjectOptional(Id = "Location")] IPlayerResourceModule playerResourceModule)
        {
            _locationModule = (LocationModule) playerResourceModule;
        }

        public ChangeGoToLocation(IChangeData data)
        {
            if (data is not ChangeGoToLocationData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _location = requiredData.LocationName;
        }

        public void Apply()
        {
            _locationModule.SetLocation(_location);
        }
    }
}