using Core.Interfaces.Domains;
using Core.Interfaces.Shop;
using Gold.ShopBlocks;
using Health;
using Zenject;

namespace Vip.Installers
{
    public class VipInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().WithId("Vip").To<VipModule>().AsSingle();
            Container.Bind<IHudResource>().To<VipHudResource>().AsSingle();
            Container.Bind<IRequirementsFactory>().To<RequirementFactory>().AsSingle();
            Container.Bind<IChangeFactory>().To<ChangeFactory>().AsSingle();
        }
    }
}
