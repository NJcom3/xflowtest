using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shop.Components
{
    public class ShowItemEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Button backButton;
        
        private ItemModule _itemModule;
        
        [Inject]
        public void Construct(
            ItemModule itemModule
        )
        {
            _itemModule = itemModule;
        }
        private void Start()
        {
            _itemModule.Init();
            backButton.onClick.AddListener(_itemModule.GoToMainScene);
        }

        private void OnDestroy()
        {
            backButton.onClick.RemoveAllListeners();
        }
    }
}