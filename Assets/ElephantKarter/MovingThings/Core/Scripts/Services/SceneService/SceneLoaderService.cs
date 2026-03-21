// using UnityEngine;
// using System.Threading;
// using System.Collections.Generic;
// using CoreDomain.Scripts.Services.Logger.Base;
// namespace CoreDomain.Scripts.Services.SceneService
// {
//     public class SceneLoaderService : ISceneLoaderService
//     {
//         private HashSet<string> _loadedScenes = new();
//         public Awaitable<bool> TryLoadScene<TEnterData>(SceneType sceneType, TEnterData enterData, CancellationTokenSource cancelationTokenSource) where TEnterData : class, IInitiatorEnterData
//         {
//             throw new System.NotImplementedException();
//         }
//         public async Awaitable<bool> TryLoadScene(string sceneName, CancellationTokenSource cancellationTokenSource)
//         {
//             var isSceneAlreaqdyLoaded = _loadedScenes.Contains(sceneName);
//             if (isSceneAlreaqdyLoaded)
//             {
//                 LogService.LogError($"scene:{sceneName} is already Loaded");
//                 return false;
//             }
//         }

//         public Awaitable StartScene<TEnterData>(SceneType gamePlayScene, TEnterData enterData, CancellationTokenSource cancellationTokenSource) where TEnterData : class, IInitiatorEnterData
//         {
//             throw new System.NotImplementedException();
//         }

//         public Awaitable<bool> TryUnloadScene(SceneType sceneType, CancellationTokenSource cancellationTokenSource)
//         {
//             throw new System.NotImplementedException();
//         }
//     }
// }