using Core;
using Core.Interfaces.Domains;
using Shop.Interfaces;
using UnityEngine;
using Zenject;

namespace Shop.Models.Changes
{
    public class ChangeAddHealthPercent : IChange
    {
        private IHealthModule _healthModule;
        private readonly int _healthPercentToAdd;

        [Inject]
        public void Construct(
            PlayerData playerData
        )
        {
            _healthModule = playerData.GetModule<IHealthModule>();;
        }

        public ChangeAddHealthPercent(int healthPercent)
        {
            _healthPercentToAdd = healthPercent;
        }

        public void Apply()
        {
            var toAdd = (int) Mathf.Ceil(_healthModule.GetCount() * (_healthPercentToAdd * 0.01f));
            _healthModule.Receive(toAdd);
        }
    }
}