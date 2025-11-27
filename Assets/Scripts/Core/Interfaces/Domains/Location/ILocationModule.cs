using Core.Interfaces.Base;

namespace Core.Interfaces.Domains
{
    public interface ILocationModule : IPlayerResourceModule
    {
        public string GetLocation();
        public void SetLocation(string location);
    }
}