using System.Threading;
using CoreDomain.Scripts.CoreInitiator.Base;
using UnityEngine;

namespace CoreDomain.Scripts.Services.InitiatorInovkerService
{
    public interface ISceneInitiatorService
    {
        void RegisterInitiator(ISceneInitiator sceneInitiator);
        void UnregisterInitiator(ISceneInitiator sceneInitiator);
        Awaitable InvokeInitiatorLoadEntryPoint(SceneType sceneType, IInitiatorEnterData enterData, CancellationTokenSource cancellationTokenSource);
        // COMMENTED
        // Awaitable InvokeInitiatorStartEntryPoint(SceneType sceneType, IInitiatorEnterData enterData, CancellationTokenSource cancellationTokenSource);
        // Awaitable InvokeInitiatorExitPoint(SceneType sceneType, CancellationTokenSource cancellationTokenSource);

    }
}

