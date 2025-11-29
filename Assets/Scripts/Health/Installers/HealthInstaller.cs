using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Gold.ShopBlocks;
using Zenject;

namespace Health.Installers
{
    public class HealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().WithId("Health").To<HealthModule>().AsSingle();
            Container.Bind<IHudResource>().To<HealthHudResource>().AsSingle();
            Container.Bind<IRequirementsFactory>().To<RequirementFactory>().AsSingle();
            Container.Bind<IChangeFactory>().To<ChangeFactory>().AsSingle();
        }
    }
}
