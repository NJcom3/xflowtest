using Core.Interfaces.Domains;
using Location;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILocationModule>().To<LocationModule>().AsSingle();
    }
}
