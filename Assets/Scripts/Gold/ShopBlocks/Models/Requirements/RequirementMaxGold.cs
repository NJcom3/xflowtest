using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Gold.ShopBlocks.Data.Requirements;

namespace Gold.ShopBlocks.Models.Requirements
{
    public class RequirementMaxGold : IRequirement
    {
        private GoldModule _goldModule;
        private readonly int _maxGold;

        [Inject]
        public void Construct([InjectOptional(Id = "Gold")] IPlayerResourceModule playerResourceModule)
        {
            _goldModule = (GoldModule) playerResourceModule;
        }

        public RequirementMaxGold(IRequirementData data)
        {
            if (data is not RequirementMaxGoldData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _maxGold = requiredData.MaxGoldCount;
        }
        
        public bool IsValid()
        {
            return _maxGold >= _goldModule.GetCount();
        }
    }
}