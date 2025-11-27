using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMaxHealth : IRequirement
    {
        private IHealthModule _healthModule;
        private readonly int _maxHealth;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();
        }

        public RequirementMaxHealth(int health)
        {
            _maxHealth = health;
        }
        
        public bool IsValid()
        {
            return _maxHealth >= _healthModule.GetCount();
        }
    }
}