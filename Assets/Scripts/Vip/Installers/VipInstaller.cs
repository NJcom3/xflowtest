using Core.Interfaces.Domains;
using Vip;
using Zenject;

public class VipInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IVipModule>().To<VipModule>().AsSingle();
    }
}
