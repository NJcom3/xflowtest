using System;
using Core;
using Core.Interfaces.Domains;
using Gold.ShopBlocks;

namespace Vip
{
    public class VipModule : ABasePlayerResourceModule, IVipModule
    {
        private DateTime _endTime = DateTime.Now.AddHours(1);

        public VipModule()
        {
            _requirementsFactory = new RequirementFactory();
            _changeFactory = new ChangeFactory();
        }

        public TimeSpan GetVipTimeSpan()
        {
            HandleNegativeVip();
            return _endTime - DateTime.Now;
        }

        public void AddTimeSpan(TimeSpan timeSpan)
        {
            HandleNegativeVip();
            _endTime = _endTime + timeSpan;
        }

        public void RemoveTimeSpan(TimeSpan timeSpan)
        {
            HandleNegativeVip();
            _endTime = _endTime - timeSpan;
        }

        private string TimeDisplayString(TimeSpan ts)
        {
            if (ts.Days >= 3) {
                var days = (int) Math.Round(ts.TotalDays);
                return $"{days.ToString()} days";
            }

            if (ts.Days >= 1) {
                return $"{ts.Days.ToString()} days {ts.Hours.ToString()} hours";
            }

            if (ts.Hours >= 1) {
                return $"{ts.Hours.ToString()} h {ts.Minutes.ToString()} m";
            }

            return $"{ts.Minutes.ToString()} m {ts.Seconds.ToString()} s";
        }

        private void HandleNegativeVip()
        {
            if (_endTime < DateTime.Now)
            {
                _endTime = DateTime.Now;
            }
        }
        
        #region [HUD]

        public string GetHudLabel()
        {
            return "VIP: ";
        }

        public void OnCheatButtonClick()
        {
            HandleNegativeVip();
            _endTime = DateTime.Now.AddHours(1);
        }

        public string GetHudValue()
        {
            HandleNegativeVip();
            return TimeDisplayString(GetVipTimeSpan());
        }

        #endregion
    }
}