using Core.Interfaces.Domains;
using Zenject;

namespace Location.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().To<LocationModule>().AsSingle();
        }
    }
}
