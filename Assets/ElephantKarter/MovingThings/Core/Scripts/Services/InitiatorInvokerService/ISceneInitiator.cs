using System.Threading;
using CoreDomain.Scripts.CoreInitiator.Base;
using UnityEngine;

public interface ISceneInitiator
{
    SceneType SceneType { get; }
    Awaitable LoadEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource);
    Awaitable StartEntryPoint(IInitiatorEnterData enterDataObject, CancellationTokenSource cancellationTokenSource);
    Awaitable InitExitPoint(CancellationTokenSource cancellationTokenSource);
}