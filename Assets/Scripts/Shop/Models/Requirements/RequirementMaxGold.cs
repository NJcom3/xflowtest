using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using Zenject;

namespace Shop.Models.Requirements
{
    public class RequirementMaxGold : IRequirement
    {
        private IGoldModule _goldModule;
        private readonly int _maxGold;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _goldModule = playerData.GetModule<IGoldModule>();
        }

        public RequirementMaxGold(int gold)
        {
            _maxGold = gold;
        }
        
        public bool IsValid()
        {
            return _maxGold >= _goldModule.GetCount();
        }
    }
}