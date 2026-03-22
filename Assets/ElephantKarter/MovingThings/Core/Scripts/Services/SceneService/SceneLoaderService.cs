using UnityEngine;
using System.Threading;
using System.Collections.Generic;
using CoreDomain.Scripts.Services.Logger.Base;
using UnityEngine.SceneManagement;
using CoreDomain.Scripts.Services.InitiatorInovkerService;
using CoreDomain.Scripts.CoreInitiator.Base;
namespace CoreDomain.Scripts.Services.SceneService
{
    public class SceneLoaderService : ISceneLoaderService
    {
        private readonly ISceneInitiatorService _sceneInitiatorsService;

        private HashSet<string> _loadedScenes = new();
        private HashSet<string> _loadingScenes = new();
        public async Awaitable<bool> TryLoadScene<TEnterData>(SceneType sceneType, TEnterData enterData, CancellationTokenSource cancelationTokenSource) where TEnterData : class, IInitiatorEnterData
        {
            if (!await TryLoadScene(sceneType.ToString(), cancelationTokenSource))
            {
                return false;
            }
            // COMMENTED
            // await _sceneInitiatorsService.InvokeInitiatorLoadEntryPoint(sceneType, enterData, cancelationTokenSource);
            return true;
        }
        public async Awaitable<bool> TryLoadScene(string sceneName, CancellationTokenSource cancellationTokenSource)
        {
            var isSceneAlreaqdyLoaded = _loadedScenes.Contains(sceneName);
            if (isSceneAlreaqdyLoaded)
            {
                LogService.LogError($"scene:{sceneName} is already Loaded");
                return false;
            }

            var isSceneAlreaqdyLoading = _loadingScenes.Contains(sceneName);
            if (isSceneAlreaqdyLoading)
            {
                LogService.LogError($"scene:{sceneName} is already loading");
                return false;
            }

            await LoadScene(sceneName, cancellationTokenSource);
            return true;
        }

        public Awaitable StartScene<TEnterData>(SceneType gamePlayScene, TEnterData enterData, CancellationTokenSource cancellationTokenSource) where TEnterData : class, IInitiatorEnterData
        {
            throw new System.NotImplementedException();
        }

        public Awaitable<bool> TryUnloadScene(SceneType sceneType, CancellationTokenSource cancellationTokenSource)
        {
            throw new System.NotImplementedException();
        }

        private async Awaitable LoadScene(string sceneName, CancellationTokenSource cancellationTokenSource)
        {
            _loadingScenes.Add(sceneName);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            _loadingScenes.Remove(sceneName);
            _loadedScenes.Add(sceneName);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}