using Core.Interfaces.Shop;
using Vip.ShopBlocks.Data.Changes;
using Vip.ShopBlocks.Models.Changes;

namespace Gold.ShopBlocks
{
    public class ChangeFactory : IChangeFactory
    {
        public IChange CreateChange(IChangeData data)
        {
            switch (data)
            {
                case ChangeAddVipTimePercentData:
                    return new ChangeAddVipTimePercent(data);
                case ChangeAddVipTimeValueData:
                    return new ChangeAddVipTimeValue(data);
                case ChangeRemoveVipTimePercentData:
                    return new ChangeRemoveVipTimePercent(data);;
                case ChangeRemoveVipTimeValueData:
                    return new ChangeRemoveVipTimeValue(data);
            }

            return null;
        }
    }
}