using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Gold.ShopBlocks;
using Zenject;

namespace Gold.Installers
{
    public class GoldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().WithId("Gold").To<GoldModule>().AsSingle();
            Container.Bind<IHudResource>().To<GoldHudResource>().AsSingle();
            Container.Bind<IRequirementsFactory>().To<RequirementFactory>().AsSingle();
            Container.Bind<IChangeFactory>().To<ChangeFactory>().AsSingle();
        }
    }
}
