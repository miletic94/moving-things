using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoreDomain.Scripts.CoreInitiator.Base;
using UnityEngine;

namespace CoreDomain.Scripts.Services.InitiatorInovkerService
{
    public class SceneInitiatorService : ISceneInitiatorService
    {
        private readonly Dictionary<SceneType, ISceneInitiator> _sceneInitiators = new();
        public void RegisterInitiator(ISceneInitiator sceneInitiator)
        {
            _sceneInitiators.Add(sceneInitiator.SceneType, sceneInitiator);
        }
        public void UnregisterInitiator(ISceneInitiator sceneInitiator)
        {
            _sceneInitiators.Remove(sceneInitiator.SceneType);
        }

        public async Awaitable InvokeInitiatorLoadEntryPoint(SceneType sceneType, IInitiatorEnterData enterData, CancellationTokenSource cancellationTokenSource)
        {
            await _sceneInitiators[sceneType].LoadEntryPoint(enterData, cancellationTokenSource);
        }
        // COMMENTED
        // Awaitable InvokeInitiatorStartEntryPoint(SceneType sceneType, IInitiatorEnterData enterData, CancellationTokenSource cancellationTokenSource);
        // Awaitable InvokeInitiatorExitPoint(SceneType sceneType, CancellationTokenSource cancellationTokenSource);
    }
}
