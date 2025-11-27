using Core.Interfaces.Base;

namespace Core.Interfaces.Domains
{
    public interface IGoldModule : IPlayerResourceModule, IHudResource, ISpendable, IReceivable, ICountable
    {
        
    }
}