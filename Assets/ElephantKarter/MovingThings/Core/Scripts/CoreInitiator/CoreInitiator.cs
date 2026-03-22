using System.Threading;
using CoreDomain.Scripts.Services.Logger.Base;
using CoreDomain.Scripts.Services.SceneService;
using UnityEngine;
using Zenject;
namespace CoreDomain.Scripts.CoreInitiator
{
    public class CoreInitiator : MonoBehaviour
    {
        private ISceneLoaderService _sceneLoaderService;
        [Inject]
        private void Setup(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }
        private void Start()
        {
            _ = InitEntryPoint(CancellationTokenSource.CreateLinkedTokenSource(Application.exitCancellationToken));
        }
        private async Awaitable InitEntryPoint(CancellationTokenSource cancellationTokenSource)
        {
            await LoadGameScene(cancellationTokenSource);
        }
        private async Awaitable LoadGameScene(CancellationTokenSource cancellationTokenSource)
        {
            await _sceneLoaderService.TryLoadScene(SceneType.GameScene, new GameInitiatorEnterData(), cancellationTokenSource);
            LogService.LogTopic("GameScene Loaded", LogTopicType.Temp);
        }
    }
}

