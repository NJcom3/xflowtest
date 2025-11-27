using Core.Events;
using Core.Interfaces.Domains;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Components
{
    public class HudItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text labelText;
        [SerializeField] private TMP_Text valueText;
        [SerializeField] private Button cheatButton;

        private IHudResource _hudResource;

        public void Init(IHudResource hudResource, EventBus eventBus)
        {
            labelText.text = hudResource.GetHudLabel();
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
}
