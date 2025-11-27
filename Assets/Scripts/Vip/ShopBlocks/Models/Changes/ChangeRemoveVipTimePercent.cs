using System;
using Core;
using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Zenject;
using Vip.ShopBlocks.Data.Changes;

namespace Vip.ShopBlocks.Models.Changes
{
    public class ChangeRemoveVipTimePercent : IChange
    {
        private IVipModule _vipModule;
        private readonly int _vipTimePercentToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _vipModule = playerData.GetModule<IVipModule>();
        }

        
        public ChangeRemoveVipTimePercent(IChangeData data)
        {
            if (data is not ChangeRemoveVipTimePercentData requiredData)
            {
                throw new Exception("Incorrect data type");
            }

            _vipTimePercentToRemove = requiredData.VipTimePercent;
        }

        public void Apply()
        {
            var toSpend = (_vipModule.GetVipTimeSpan() * (_vipTimePercentToRemove * 0.01f));
            _vipModule.RemoveTimeSpan(toSpend);
        }
    }
}