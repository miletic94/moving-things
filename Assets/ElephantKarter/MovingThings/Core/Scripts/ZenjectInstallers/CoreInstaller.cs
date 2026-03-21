using CoreDomain.Scripts.Services.Logger;
using Zenject;
namespace CoreDomain.Scripts.ZenjectInstallers
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityLogger>().AsSingle().NonLazy();
        }
    }
}