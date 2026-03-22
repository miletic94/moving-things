using CoreDomain.Scripts.Services.InitiatorInovkerService;
using CoreDomain.Scripts.Services.Logger;
using CoreDomain.Scripts.Services.SceneService;
using Zenject;
namespace CoreDomain.Scripts.ZenjectInstallers
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorService>().AsSingle().NonLazy();
        }
    }
}