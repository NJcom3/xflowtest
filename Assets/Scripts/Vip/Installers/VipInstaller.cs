using Core.Interfaces.Domains;
using Zenject;

namespace Vip.Installers
{
    public class VipInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().To<VipModule>().AsSingle(); 
        }
    }
}
