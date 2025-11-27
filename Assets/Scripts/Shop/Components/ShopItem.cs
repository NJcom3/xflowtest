using System;
using Core.Events;
using Shop.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop.Components
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text descText;
        [SerializeField] private TMP_Text buyButtonText;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button buyButton;

        private ShopItemModel _model;
        private EventBus _eventBus;
        
        private bool _isLoading = false;

        [Inject]
        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public void Init(ShopItemModel model)
        {
            _model = model;
            descText.text = _model.ItemName;
            
            if (infoButton.gameObject.activeSelf)
            {
                infoButton.onClick.AddListener(_model.SwitchToItemScene);
            }
            
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(TryToBuy);
            
            _eventBus.Subscribe<ValuesChanged>(RefreshState);
            RefreshState(false);
        }

        private void RefreshState(bool v)
        {
            if (_isLoading)
            {
                return;
            }

            buyButton.interactable = _model.CanBeBuyed();
        }

        private async void TryToBuy()
        {
            if (_model.CanBeBuyed())
            {
                _isLoading = true;
                buyButton.interactable = false;
                buyButtonText.text = "Обработка...";
                
                await _model.TryToBuy();

                _isLoading = false;
                buyButton.interactable = true;
                buyButtonText.text = "Купить";
            }

            _eventBus.Publish<ValuesChanged>();
        }

        private void OnDestroy()
        {
            if (infoButton.gameObject.activeSelf)
            {
                infoButton.onClick.RemoveAllListeners();
            }
            
            buyButton.onClick.RemoveAllListeners();
            _eventBus.Unsubscribe<ValuesChanged>(RefreshState);
        }
    }
}
