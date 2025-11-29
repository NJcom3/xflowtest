using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Gold.ShopBlocks;
using Zenject;

namespace Location.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().WithId("Location").To<LocationModule>().AsSingle();
            Container.Bind<IHudResource>().To<LocationHudResource>().AsSingle();
            Container.Bind<IRequirementsFactory>().To<RequirementFactory>().AsSingle();
            Container.Bind<IChangeFactory>().To<ChangeFactory>().AsSingle();
        }
    }
}
