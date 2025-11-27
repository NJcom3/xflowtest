using Core.Interfaces.Shop;

namespace Core.Interfaces.Domains
{
    public interface IPlayerResourceModule
    {
        public IRequirement CreateRequirement(IRequirementData data);
        public IChange CreateChange(IChangeData data);
    }
}