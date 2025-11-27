using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Hud hud;

        public override void InstallBindings()
        {
            Container.Bind<Hud>().FromInstance(hud).AsSingle();
        }
    }
}