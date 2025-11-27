using Core.Interfaces.Shop;
using Health.ShopBlocks.Data.Requirements;
using Health.ShopBlocks.Models.Requirements;

namespace Gold.ShopBlocks
{
    public class RequirementFactory : IRequirementsFactory
    {
        public IRequirement CreateRequirement(IRequirementData data)
        {
            switch (data)
            {
                case RequirementMaxHealthData:
                    return new RequirementMaxHealth(data);
                case RequirementMinHealthData:
                    return new RequirementMinHealth(data);
            }

            return null;
        }
    }
}