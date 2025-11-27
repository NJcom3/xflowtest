namespace Core.Interfaces.Shop
{
    public interface IChangeData
    {
#if UNITY_EDITOR
        public void RenderEdit();
#endif
    }
}