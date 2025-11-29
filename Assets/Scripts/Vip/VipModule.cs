using System;
using Core.Interfaces.Domains;

namespace Vip
{
    public class VipModule : IPlayerResourceModule
    {
        private DateTime EndTime
        {
            get => _endTimeValue >= DateTime.Now ? _endTimeValue : DateTime.Now;
            set => _endTimeValue = value;
        }
        
        private DateTime _endTimeValue;

        public VipModule()
        {
            EndTime = DateTime.Now.AddHours(1);
        }

        public TimeSpan GetVipTimeSpan()
        {
            return EndTime - DateTime.Now;
        }

        public void AddTimeSpan(TimeSpan timeSpan)
        {
            HandleNegativeVip();
            EndTime += timeSpan;
        }

        public void RemoveTimeSpan(TimeSpan timeSpan)
        {
            HandleNegativeVip();
            EndTime -= timeSpan;
        }
        
        private void HandleNegativeVip()
        {
            if (EndTime < DateTime.Now)
            {
                EndTime = DateTime.Now;
            }
        }
    }
}