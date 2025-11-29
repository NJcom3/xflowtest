using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Vip.ShopBlocks.Data.Requirements;

namespace Vip.ShopBlocks.Models.Requirements
{
    public class RequirementMaxVipTime : IRequirement
    {
        private VipModule _vipModule;
        private readonly TimeSpan _maxVipTime;

        [Inject]
        public void Construct([InjectOptional(Id = "Vip")] IPlayerResourceModule playerResourceModule)
        {
            _vipModule = (VipModule) playerResourceModule;
        }
        
        public RequirementMaxVipTime(IRequirementData data)
        {
            if (data is not RequirementMaxVipTimeData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _maxVipTime = TimeSpan.FromSeconds(requiredData.MaxVipSeconds) + 
                       TimeSpan.FromMinutes(requiredData.MaxVipMinutes) + 
                       TimeSpan.FromHours(requiredData.MaxVipHours);
        }

        public bool IsValid()
        {
            return _maxVipTime >= _vipModule.GetVipTimeSpan();
        }
    }
}