using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Vip.ShopBlocks.Data.Changes;

namespace Vip.ShopBlocks.Models.Changes
{
    public class ChangeAddVipTimePercent : IChange
    {
        private IVipModule _vipModule;
        private readonly int _vipTimePercentToAdd;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _vipModule = playerData.GetModule<IVipModule>();
        }
        
        public ChangeAddVipTimePercent(IChangeData data)
        {
            if (data is not ChangeAddVipTimePercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _vipTimePercentToAdd = requiredData.VipTimePercent;
        }

        public void Apply()
        {
            var toAdd = (_vipModule.GetVipTimeSpan() * (_vipTimePercentToAdd * 0.01f));
            _vipModule.AddTimeSpan(toAdd);
        }
    }
}