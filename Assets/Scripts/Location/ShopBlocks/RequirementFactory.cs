using Core.Interfaces.Shop;
using Location.ShopBlocks.Data.Requirements;
using Location.ShopBlocks.Models.Requirements;

namespace Gold.ShopBlocks
{
    public class RequirementFactory : IRequirementsFactory
    {
        public IRequirement CreateRequirement(IRequirementData data)
        {
            switch (data)
            {
                case RequirementAllowedLocationData:
                    return new RequirementAllowedLocations(data);
                case RequirementNotAllowedLocationData:
                    return new RequirementNotAllowedLocations(data);
            }

            return null;
        }
    }
}