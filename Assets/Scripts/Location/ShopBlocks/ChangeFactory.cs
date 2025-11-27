using Core.Interfaces.Shop;
using Location.ShopBlocks.Data.Changes;
using Location.ShopBlocks.Models.Changes;

namespace Gold.ShopBlocks
{
    public class ChangeFactory : IChangeFactory
    {
        public IChange CreateChange(IChangeData data)
        {
            switch (data)
            {
                case ChangeGoToLocationData:
                    return new ChangeGoToLocation(data);
            }

            return null;
        }
    }
}