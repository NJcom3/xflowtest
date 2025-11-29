using Core.Interfaces.Domains;
using Zenject;

namespace Health
{
    public class HealthHudResource : IHudResource
    {
        private HealthModule _healthModule;

        [Inject]
        public void Construct([InjectOptional(Id = "Health")] IPlayerResourceModule playerResourceModule)
        {
            _healthModule = (HealthModule) playerResourceModule;
        }
        
        public string GetHudLabel()
        {
            return "Health: ";
        }
        
        public void OnCheatButtonClick()
        {
            _healthModule.Receive(25);
        }

        public string GetHudValue()
        {
            return _healthModule.GetCount().ToString();
        }
    }
}