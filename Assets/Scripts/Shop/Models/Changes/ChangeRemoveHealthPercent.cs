using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using UnityEngine;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeRemoveHealthPercent : IChange
    {
        private IHealthModule _healthModule;
        private readonly int _healthPercentToRemove;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();
        }

        public ChangeRemoveHealthPercent(int healthPercent)
        {
            _healthPercentToRemove = healthPercent;
        }

        public void Apply()
        {
            var toSpend = (int) Mathf.Ceil(_healthModule.GetCount() * (_healthPercentToRemove * 0.01f));
            _healthModule.Spend(toSpend);
        }
    }
}