using Core.Interfaces.Base;

namespace Core.Interfaces.Domains
{
    public interface IGoldModule : ISpendable, IReceivable, ICountable, IPlayerResourceModule
    {
        
    }
}