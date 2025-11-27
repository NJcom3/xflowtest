using System;
using System.Collections.Generic;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Location.ShopBlocks.Data.Requirements;

namespace Location.ShopBlocks.Models.Requirements
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

        public RequirementAllowedLocations(IRequirementData data)
        {
            if (data is not RequirementAllowedLocationData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _allowedLocations = requiredData.AllowedLocationList;
        }
        
        public bool IsValid()
        {
            return _allowedLocations.Contains(_locationModule.GetLocation());
        }
    }
}