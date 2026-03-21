using UnityEngine;
using System.Threading;
namespace CoreDomain.Scripts.Services.SceneService
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public Awaitable<bool> TryLoadScene<TEnterData>(SceneType sceneType, TEnterData enterData, CancellationTokenSource cancelationTokenSource) where TEnterData : class, IInitiatorEnterData
        {
            throw new System.NotImplementedException();
        }

        public Awaitable StartScene<TEnterData>(SceneType gamePlayScene, TEnterData enterData, CancellationTokenSource cancellationTokenSource) where TEnterData : class, IInitiatorEnterData
        {
            throw new System.NotImplementedException();
        }

        public Awaitable<bool> TryUnloadScene(SceneType sceneType, CancellationTokenSource cancellationTokenSource)
        {
            throw new System.NotImplementedException();
        }
    }
}