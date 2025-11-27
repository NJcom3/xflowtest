using Core.Events;
using Zenject;

namespace Core.Installers
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<PlayerData>().AsSingle();
        }
    }
}
