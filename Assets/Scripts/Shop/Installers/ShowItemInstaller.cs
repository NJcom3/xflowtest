using Shop.Components;
using Shop.Models;
using Shop.Scriptables;
using UnityEngine;
using Zenject;

namespace Shop.Installers
{
    public class ShowItemInstaller : MonoInstaller
    {
        public ShopScriptable shopScriptable;
        public ShopItem shopItem;
        public ShowItemEntryPoint showItemEntryPoint;
        
        public override void InstallBindings()
        {
            Container.Bind<ShopItemFactory>().AsSingle();
            Container.Bind<ShopScriptable>().FromInstance(shopScriptable).AsSingle();
            Container.Bind<ShopItem>().FromInstance(shopItem).AsSingle();
            Container.Bind<ItemModule>().AsSingle();
            Container.Bind<ShopModule>().AsSingle();
            Container.Bind<ShowItemEntryPoint>().FromInstance(showItemEntryPoint).AsSingle();
        }
    }
}
