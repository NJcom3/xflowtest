using System.Collections.Generic;
using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementAllowedLocations : IRequirement
    {
        private ILocationModule _locationModule;
        private readonly List<string> _allowedLocations;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _locationModule = playerData.GetModule<ILocationModule>();
        }

        public RequirementAllowedLocations(List<string> locations)
        {
            _allowedLocations = locations;
        }
        
        public bool IsValid()
        {
            return _allowedLocations.Contains(_locationModule.GetLocation());
        }
    }
}