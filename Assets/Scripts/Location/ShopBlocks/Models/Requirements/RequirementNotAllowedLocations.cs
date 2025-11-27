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
        private PlayerData _playerData;
        private readonly List<string> _notAllowedLocations;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _playerData = playerData;
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
            var locationModule = _playerData.GetModule<ILocationModule>();
            return !_notAllowedLocations.Contains(locationModule.GetLocation());
        }
    }
}