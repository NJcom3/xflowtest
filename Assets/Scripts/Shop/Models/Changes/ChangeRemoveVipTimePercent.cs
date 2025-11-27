using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
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

        public ChangeRemoveVipTimePercent(int vipTimePercent)
        {
            _vipTimePercentToRemove = vipTimePercent;
        }

        public void Apply()
        {
            var toSpend = (_vipModule.GetVipTimeSpan() * (_vipTimePercentToRemove * 0.01f));
            _vipModule.RemoveTimeSpan(toSpend);
        }
    }
}