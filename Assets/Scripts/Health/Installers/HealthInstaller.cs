using Core.Interfaces.Domains;
using Zenject;

namespace Health.Installers
{
    public class HealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().To<HealthModule>().AsSingle();
        }
    }
}
