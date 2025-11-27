using Core.Interfaces.Domains;
using Gold;
using Zenject;

public class GoldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGoldModule>().To<GoldModule>().AsSingle();
    }
}
