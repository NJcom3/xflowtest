using System;
using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMinVipTime : IRequirement
    {
        private IVipModule _vipModule;
        private readonly TimeSpan _minVipTime;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _vipModule = playerData.GetModule<IVipModule>();
        }

        public RequirementMinVipTime(int hours, int minutes, int seconds)
        {
            _minVipTime = TimeSpan.FromSeconds(seconds) + TimeSpan.FromMinutes(minutes) + TimeSpan.FromHours(hours);
        }
        
        public bool IsValid()
        {
            return _minVipTime <= _vipModule.GetVipTimeSpan();
        }
    }
}