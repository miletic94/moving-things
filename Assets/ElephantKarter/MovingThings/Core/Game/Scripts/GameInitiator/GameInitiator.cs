using System.Threading;
using System.Threading.Tasks;
using CoreDomain.Scripts.CoreInitiator.Base;
using CoreDomain.Scripts.Services.InitiatorInovkerService;
using CoreDomain.Scripts.Services.Logger.Base;
using UnityEngine;

namespace CoreDomain.GameDomain.Scripts.GameInitiator
{
    public class GameInitiator : ISceneInitiator, IGameInitiator
    {
        ISceneInitiatorService _sceneInitiatorService;
        public GameInitiator(ISceneInitiatorService sceneInitiatorService)
        {
            _sceneInitiatorService = sceneInitiatorService;
            _sceneInitiatorService.RegisterInitiator(this);
        }
        public SceneType SceneType => SceneType.GameScene;

        public async Awaitable LoadEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource)
        {
            LogService.Log("GameInitiator LoadEntryPoint");
            await Task.Yield();
        }
        // COMMENTED
        // Awaitable StartEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource);
        // Awaitable InitExitPoint(CancellationTokenSource cancellationTokenSource);
    }
}