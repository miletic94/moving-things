using CoreDomain.GameDomain.Scripts.GameInitiator;
using Zenject;

namespace CoreDomain.GameDomain.Scripts.ZenjectInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameInitiator>().To<GameInitiator.GameInitiator>().AsSingle().NonLazy();
        }
    }
}