using System;
using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMaxVipTime : IRequirement
    {
        private IVipModule _vipModule;
        private readonly TimeSpan _maxVipTime;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _vipModule = playerData.GetModule<IVipModule>();
        }

        public RequirementMaxVipTime(int hours, int minutes, int seconds)
        {
            _maxVipTime = TimeSpan.FromSeconds(seconds) + TimeSpan.FromMinutes(minutes) + TimeSpan.FromHours(hours);
        }
        
        public bool IsValid()
        {
            return _maxVipTime >= _vipModule.GetVipTimeSpan();
        }
    }
}