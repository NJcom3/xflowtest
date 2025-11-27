using Core.Interfaces.Shop;
using Health.ShopBlocks.Data.Changes;
using Health.ShopBlocks.Models.Changes;

namespace Gold.ShopBlocks
{
    public class ChangeFactory : IChangeFactory
    {
        public IChange CreateChange(IChangeData data)
        {
            switch (data)
            {
                case ChangeAddHealthPercentData:
                    return new ChangeAddHealthPercent(data);
                case ChangeAddHealthValueData:
                    return new ChangeAddHealthValue(data);
                case ChangeRemoveHealthPercentData:
                    return new ChangeRemoveHealthPercent(data);
                case ChangeRemoveHealthValueData:
                    return new ChangeRemoveHealthValue(data);
            }

            return null;
        }
    }
}