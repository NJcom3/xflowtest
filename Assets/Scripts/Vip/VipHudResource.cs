using System;
using Core.Interfaces.Domains;
using Vip;
using Zenject;

namespace Health
{
    public class VipHudResource : IHudResource
    {
        private VipModule _vipModule;

        [Inject]
        public void Construct([InjectOptional(Id = "Vip")] IPlayerResourceModule playerResourceModule)
        {
            _vipModule = (VipModule) playerResourceModule;
        }

        public string GetHudLabel()
        {
            return "VIP: ";
        }

        public void OnCheatButtonClick()
        {
            _vipModule.AddTimeSpan(TimeSpan.FromHours(1));
        }

        public string GetHudValue()
        {
            return TimeDisplayString();
        }

        private string TimeDisplayString()
        {
            var ts = _vipModule.GetVipTimeSpan();
            switch (ts.Days)
            {
                case >= 3:
                {
                    var days = (int) Math.Round(ts.TotalDays);
                    return $"{days.ToString()} days";
                }
                case >= 1:
                    return $"{ts.Days.ToString()} days {ts.Hours.ToString()} hours";
            }

            return ts.Hours >= 1 ? $"{ts.Hours.ToString()} h {ts.Minutes.ToString()} m" : 
                $"{ts.Minutes.ToString()} m {ts.Seconds.ToString()} s";
        }

    }
}