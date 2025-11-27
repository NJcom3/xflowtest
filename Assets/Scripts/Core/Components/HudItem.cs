using Core.Events;
using Core.Interfaces.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudItem : MonoBehaviour
{
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private Button cheatButton;

    private IHudResource _hudResource;

    public void Init(IHudResource hudResource, EventBus eventBus)
    {
        _hudResource = hudResource;
        cheatButton.onClick.AddListener(_hudResource.OnCheatButtonClick);
        cheatButton.onClick.AddListener(eventBus.Publish<ValuesChanged>);
    }

    public void RefreshValue()
    {
        valueText.text = _hudResource.GetHudValue();
    }
    
    private void OnDestroy()
    {
        cheatButton.onClick.RemoveAllListeners();
    }
}
