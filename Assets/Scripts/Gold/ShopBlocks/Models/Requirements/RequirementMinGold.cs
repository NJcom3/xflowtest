using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Gold.ShopBlocks.Data.Requirements;

namespace Gold.ShopBlocks.Models.Requirements
{
    public class RequirementMinGold : IRequirement
    {
        private GoldModule _goldModule;
        private readonly int _minGold;

        [Inject]
        public void Construct([InjectOptional(Id = "Gold")] IPlayerResourceModule playerResourceModule)
        {
            _goldModule = (GoldModule) playerResourceModule;
        }

        public RequirementMinGold(IRequirementData data)
        {
            if (data is not RequirementMinGoldData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _minGold = requiredData.MinGoldCount;
        }
        
        public bool IsValid()
        {
            return _minGold <= _goldModule.GetCount();
        }
    }
}