using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMinHealth : IRequirement
    {
        private IHealthModule _healthModule;
        private readonly int _minHealth;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();
        }

        public RequirementMinHealth(int health)
        {
            _minHealth = health;
        }
        
        public bool IsValid()
        {
            return _minHealth <= _healthModule.GetCount();
        }
    }
}