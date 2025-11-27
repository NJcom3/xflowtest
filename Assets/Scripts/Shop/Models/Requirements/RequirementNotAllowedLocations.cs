using System.Collections.Generic;
using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementNotAllowedLocations : IRequirement
    {
        private PlayerData _playerData;
        private readonly List<string> _notAllowedLocations;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _playerData = playerData;
        }

        public RequirementNotAllowedLocations(List<string> locations)
        {
            _notAllowedLocations = locations;
        }
        
        public bool IsValid()
        {
            var locationModule = _playerData.GetModule<ILocationModule>();
            return !_notAllowedLocations.Contains(locationModule.GetLocation());
        }
    }
}