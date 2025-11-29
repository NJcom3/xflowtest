using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Health.ShopBlocks.Data.Requirements;
using Zenject;

namespace Health.ShopBlocks.Models.Requirements
{
    public class RequirementMaxHealth : IRequirement
    {
        private HealthModule _healthModule;
        private readonly int _maxHealth;

        [Inject]
        public void Construct([InjectOptional(Id = "Health")] IPlayerResourceModule playerResourceModule)
        {
            _healthModule = (HealthModule) playerResourceModule;
        }
        
        public RequirementMaxHealth(IRequirementData data)
        {
            if (data is not RequirementMaxHealthData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _maxHealth = requiredData.MaxHealthCount;
        }
        
        public bool IsValid()
        {
            return _maxHealth >= _healthModule.GetCount();
        }
    }
}