using System.Collections.Generic;
using Core.Events;
using Core.Interfaces.Domains;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Components
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private HudItem hudItemPrefab;
        [SerializeField] private RectTransform hudItemsContainer;

        private IHudResource[] _hudResources;
        private EventBus _eventBus;

        private List<HudItem> _hudItems;
    
        [Inject]
        public void Construct(
            IHudResource[] hudResources,
            EventBus eventBus
        )
        {
            _hudResources = hudResources;
            _eventBus = eventBus;
        }

        private void Start()
        {
            InitHudItems();
            RefreshValues(false);
            _eventBus.Subscribe<ValuesChanged>(RefreshValues);
        }

        private void InitHudItems()
        {
            _hudItems = new List<HudItem>();
            foreach (var hudResource in _hudResources)
            {
                var hudItem = Instantiate(hudItemPrefab, hudItemsContainer);
                hudItem.Init(hudResource, _eventBus);
                _hudItems.Add(hudItem);
            }
        }

        private void RefreshValues(bool v)
        {
            foreach (var hudItem in _hudItems)
            {
                hudItem.RefreshValue();
            }
        
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<ValuesChanged>(RefreshValues);
        }
    }
}
