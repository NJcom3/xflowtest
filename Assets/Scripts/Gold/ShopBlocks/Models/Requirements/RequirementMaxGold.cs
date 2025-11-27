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
        private IGoldModule _goldModule;
        private readonly int _maxGold;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
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