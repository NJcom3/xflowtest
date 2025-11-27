using Core.Interfaces.Shop;
using Gold.ShopBlocks.Data.Requirements;
using Gold.ShopBlocks.Models.Requirements;

namespace Gold.ShopBlocks
{
    public class RequirementFactory : IRequirementsFactory
    {
        public IRequirement CreateRequirement(IRequirementData data)
        {
            switch (data)
            {
                case RequirementMaxGoldData:
                    return new RequirementMaxGold(data);
                case RequirementMinGoldData:
                    return new RequirementMinGold(data);
            }

            return null;
        }
    }
}