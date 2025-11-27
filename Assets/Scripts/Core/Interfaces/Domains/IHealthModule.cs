using Core.Interfaces.Base;

namespace Core.Interfaces.Domains
{
    public interface IHealthModule : IPlayerResourceModule, IHudResource, ISpendable, IReceivable, ICountable
    {
        
    }
}