using Shop.Components;
using Shop.Models;
using Shop.Scriptables;
using Zenject;

namespace Shop.Installers
{
    public class ShopInstaller : MonoInstaller
    {
        public ShopScriptable shopScriptable;
        public ShopItem shopItem;
        public ItemsContainer itemsContainer;
        public ShopEntryPoint shopEntryPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<ShopItemFactory>().AsSingle();
            Container.Bind<ShopScriptable>().FromInstance(shopScriptable).AsSingle();
            Container.Bind<ItemsContainer>().FromInstance(itemsContainer).AsSingle();
            Container.Bind<ShopItem>().FromComponentInNewPrefab(shopItem).AsTransient();
            Container.Bind<ShopModule>().AsSingle();
            Container.Bind<ShopEntryPoint>().FromInstance(shopEntryPoint).AsSingle();
        }
    }
}
