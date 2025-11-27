using System;
using Core.Interfaces.Base;

namespace Core.Interfaces.Domains
{
    public interface IVipModule : IPlayerResourceModule
    {
        public TimeSpan GetVipTimeSpan();
        public void AddTimeSpan(TimeSpan timeSpan);
        public void RemoveTimeSpan(TimeSpan timeSpan);
    }
}