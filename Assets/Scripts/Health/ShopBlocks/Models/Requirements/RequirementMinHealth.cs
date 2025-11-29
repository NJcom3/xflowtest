using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Health.ShopBlocks.Data.Requirements;
using Zenject;

namespace Health.ShopBlocks.Models.Requirements
{
    public class RequirementMinHealth : IRequirement
    {
        private HealthModule _healthModule;
        private readonly int _minHealth;

        [Inject]
        public void Construct([InjectOptional(Id = "Health")] IPlayerResourceModule playerResourceModule)
        {
            _healthModule = (HealthModule) playerResourceModule;
        }

        public RequirementMinHealth(IRequirementData data)
        {
            if (data is not RequirementMinHealthData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _minHealth = requiredData.MinHealthCount;
        }
        
        public bool IsValid()
        {
            return _minHealth <= _healthModule.GetCount();
        }

    }
}