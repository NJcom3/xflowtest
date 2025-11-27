namespace Core.Interfaces.Shop
{
    public interface IRequirementsFactory
    {
        public IRequirement CreateRequirement(IRequirementData data);
    }
}