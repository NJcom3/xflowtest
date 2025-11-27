using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
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

        public ChangeAddVipTimePercent(int vipTimePercent)
        {
            _vipTimePercentToAdd = vipTimePercent;
        }

        public void Apply()
        {
            var toAdd = (_vipModule.GetVipTimeSpan() * (_vipTimePercentToAdd * 0.01f));
            _vipModule.AddTimeSpan(toAdd);
        }
    }
}