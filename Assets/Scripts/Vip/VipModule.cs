using System;
using Core.Interfaces.Domains;

namespace Vip
{
    public class VipModule : IVipModule
    {
        private DateTime _endTime = DateTime.Now.AddHours(1);
        
        public TimeSpan GetVipTimeSpan()
        {
            return _endTime - DateTime.Now;
        }

        public void AddTimeSpan(TimeSpan timeSpan)
        {
            _endTime = _endTime + timeSpan;
        }

        public void RemoveTimeSpan(TimeSpan timeSpan)
        {
            _endTime = _endTime - timeSpan;
        }

        public void OnCheatButtonClick()
        {
            _endTime = DateTime.Now.AddHours(1);
        }

        public string GetHudValue()
        {
            return TimeDisplayString(GetVipTimeSpan());
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
    }
}