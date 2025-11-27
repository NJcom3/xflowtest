using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMinGold : IRequirement
    {
        private IGoldModule _goldModule;
        private readonly int _minGold;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public RequirementMinGold(int gold)
        {
            _minGold = gold;
        }
        
        public bool IsValid()
        {
            return _minGold <= _goldModule.GetCount();
        }
    }
}