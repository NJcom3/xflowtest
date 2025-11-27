using UnityEngine;
using Zenject;

namespace Shop.Components
{
    public class ShopEntryPoint : MonoBehaviour
    {
        private ShopModule _shopModule;
        
        [Inject]
        public void Construct(
            ShopModule shopModule
        )
        {
            _shopModule = shopModule;
        }
        private void Start()
        {
            _shopModule.RenderShop();
        }
    }
}