using Core.Interfaces.Domains;
using Zenject;

namespace Gold
{
    public class GoldHudResource : IHudResource
    {
        private GoldModule _goldModule;

        [Inject]
        public void Construct([InjectOptional(Id = "Gold")] IPlayerResourceModule playerResourceModule)
        {
            _goldModule = (GoldModule) playerResourceModule;
        }
        
        public string GetHudLabel()
        {
            return "Gold: ";
        }
        
        public void OnCheatButtonClick()
        {
            _goldModule.Receive(100);
        }

        public string GetHudValue()
        {
            return _goldModule.GetCount().ToString();
        }
    }
}