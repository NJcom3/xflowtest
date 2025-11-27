using Core.Interfaces.Domains;
using Core.Interfaces.Shop;

namespace Core
{
    public abstract class ABasePlayerResourceModule : IPlayerResourceModule
    {
        protected IRequirementsFactory _requirementsFactory;
        protected IChangeFactory _changeFactory;
        
        public IRequirement CreateRequirement(IRequirementData data)
        {
            return _requirementsFactory.CreateRequirement(data);
        }

        public IChange CreateChange(IChangeData data)
        {
            return _changeFactory.CreateChange(data);
        }
    }
}