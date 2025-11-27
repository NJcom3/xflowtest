namespace Core.Interfaces.Domains
{
    public interface IHudResource
    {
        public void OnCheatButtonClick();
        public string GetHudValue();
        public string GetHudLabel();
    }
}