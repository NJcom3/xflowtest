using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeGoToLocation : IChange
    {
        private ILocationModule _locationModule;
        private readonly string _location;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _locationModule = playerData.GetModule<ILocationModule>();
        }

        public ChangeGoToLocation(string location)
        {
            _location = location;
        }

        public void Apply()
        {
            _locationModule.SetLocation(_location);
        }
    }
}