using Core.Interfaces.Domains;
using Health;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IHealthModule>().To<HealthModule>().AsSingle();
    }
}
