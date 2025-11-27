namespace Core.Interfaces.Shop
{
    public interface IChangeFactory
    {
        public IChange CreateChange(IChangeData data);
    }
}