using Core;
using Core.Events;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EventBus>().AsSingle();
        Container.Bind<PlayerData>().AsSingle();
    }
}
