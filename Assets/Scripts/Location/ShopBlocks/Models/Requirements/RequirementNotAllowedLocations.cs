using System;
using System.Collections.Generic;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Location.ShopBlocks.Data.Requirements;

namespace Location.ShopBlocks.Models.Requirements
{
    public class RequirementNotAllowedLocations : IRequirement
    {
        private LocationModule _locationModule;
        private readonly List<string> _notAllowedLocations;

        [Inject]
        public void Construct([InjectOptional(Id = "Location")] IPlayerResourceModule playerResourceModule)
        {
            _locationModule = (LocationModule) playerResourceModule;
        }
        
        public RequirementNotAllowedLocations(IRequirementData data)
        {
            if (data is not RequirementNotAllowedLocationData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _notAllowedLocations = requiredData.NotAllowedLocationList;
        }
        
        public bool IsValid()
        {
            return !_notAllowedLocations.Contains(_locationModule.GetLocation());
        }
    }
}