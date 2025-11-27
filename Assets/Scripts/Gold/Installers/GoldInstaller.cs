using Core.Interfaces.Domains;
using Zenject;

namespace Gold.Installers
{
    public class GoldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResourceModule>().To<GoldModule>().AsSingle();
        }
    }
}
