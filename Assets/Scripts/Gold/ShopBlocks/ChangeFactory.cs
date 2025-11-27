using Core.Interfaces.Shop;
using Gold.ShopBlocks.Data.Changes;
using Gold.ShopBlocks.Models.Changes;

namespace Gold.ShopBlocks
{
    public class ChangeFactory : IChangeFactory
    {
        public IChange CreateChange(IChangeData data)
        {
            switch (data)
            {
                case ChangeAddGoldPercentData:
                    return new ChangeAddGoldPercent(data);
                case ChangeAddGoldValueData:
                    return new ChangeAddGoldValue(data);
                case ChangeRemoveGoldPercentData:
                    return new ChangeRemoveGoldPercent(data);
                case ChangeRemoveGoldValueData:
                    return new ChangeRemoveGoldValue(data);
            }

            return null;
        }
    }
}