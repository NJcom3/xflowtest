using System;
using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Changes
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

        public ChangeAddVipTimeValue(int hours, int minutes, int seconds)
        {
            _vipTime = TimeSpan.FromSeconds(seconds) + TimeSpan.FromMinutes(minutes) + TimeSpan.FromHours(hours);
        }

        public void Apply()
        {
            _vipModule.AddTimeSpan(_vipTime);
        }
    }
}