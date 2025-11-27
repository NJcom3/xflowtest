using Core.Interfaces.Shop;
using Vip.ShopBlocks.Data.Requirements;
using Vip.ShopBlocks.Models.Requirements;

namespace Gold.ShopBlocks
{
    public class RequirementFactory : IRequirementsFactory
    {
        public IRequirement CreateRequirement(IRequirementData data)
        {
            switch (data)
            {
                case RequirementMaxVipTimeData:
                    return new RequirementMaxVipTime(data);
                case RequirementMinVipTimeData:
                    return new RequirementMinVipTime(data);
            }

            return null;
        }
    }
}