using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Vip.ShopBlocks.Data.Changes;

namespace Vip.ShopBlocks.Models.Changes
{
    public class ChangeAddVipTimeValue : IChange
    {
        private IVipModule _vipModule;
        private readonly TimeSpan _vipTime;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _vipModule = playerData.GetModule<IVipModule>();
        }
        
        public ChangeAddVipTimeValue(IChangeData data)
        {
            if (data is not ChangeAddVipTimeValueData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _vipTime = TimeSpan.FromSeconds(requiredData.VipSeconds) + 
                       TimeSpan.FromMinutes(requiredData.VipMinutes) + 
                       TimeSpan.FromHours(requiredData.VipHours);
        }

        public void Apply()
        {
            _vipModule.AddTimeSpan(_vipTime);
        }
    }
}