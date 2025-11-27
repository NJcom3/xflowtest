using System;
using System.Collections.Generic;
using Core;
using Core.Events;
using Core.Interfaces.Domains;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Hud : MonoBehaviour
{
    [SerializeField] private HudItem healthHudItem;
    [SerializeField] private HudItem goldHudItem;
    [SerializeField] private HudItem locationHudItem;
    [SerializeField] private HudItem vipHudItem;

    [SerializeField] private HorizontalLayoutGroup layoutGroup;

    private PlayerData _playerData;
    private EventBus _eventBus;

    private List<HudItem> _hudItems;
    
    [Inject]
    public void Construct(
        PlayerData playerData,
        EventBus eventBus
        )
    {
        _playerData = playerData;
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
        healthHudItem.Init(_playerData.GetModule<IHealthModule>(), _eventBus);
        goldHudItem.Init(_playerData.GetModule<IGoldModule>(), _eventBus);
        locationHudItem.Init(_playerData.GetModule<ILocationModule>(), _eventBus);
        vipHudItem.Init(_playerData.GetModule<IVipModule>(), _eventBus);

        _hudItems = new List<HudItem> {healthHudItem, goldHudItem, locationHudItem, vipHudItem};
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
