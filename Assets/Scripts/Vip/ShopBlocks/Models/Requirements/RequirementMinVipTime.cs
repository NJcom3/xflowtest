using System;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Vip.ShopBlocks.Data.Requirements;

namespace Vip.ShopBlocks.Models.Requirements
{
    public class RequirementMinVipTime : IRequirement
    {
        private VipModule _vipModule;
        private readonly TimeSpan _minVipTime;

        [Inject]
        public void Construct([InjectOptional(Id = "Vip")] IPlayerResourceModule playerResourceModule)
        {
            _vipModule = (VipModule) playerResourceModule;
        }

        public RequirementMinVipTime(IRequirementData data)
        {
            if (data is not RequirementMinVipTimeData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _minVipTime = TimeSpan.FromSeconds(requiredData.MinVipSeconds) + 
                          TimeSpan.FromMinutes(requiredData.MinVipMinutes) + 
                          TimeSpan.FromHours(requiredData.MinVipHours);
        }
        
        public bool IsValid()
        {
            return _minVipTime <= _vipModule.GetVipTimeSpan();
        }
    }
}