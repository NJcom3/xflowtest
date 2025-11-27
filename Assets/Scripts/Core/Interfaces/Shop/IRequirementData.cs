namespace Core.Interfaces.Shop
{
    public interface IRequirementData
    {

#if UNITY_EDITOR
        public void RenderEdit();

#endif
    }
}