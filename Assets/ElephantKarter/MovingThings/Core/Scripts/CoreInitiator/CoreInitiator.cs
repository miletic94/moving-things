using CoreDomain.Scripts.Services.Logger.Base;
using UnityEngine;
namespace CoreDomain.Scripts.CoreInitiator
{
    public class CoreInitiator : MonoBehaviour
    {
        private void Start()
        {
            InitEntryPoint();
        }
        private void InitEntryPoint()
        {
            LogService.LogTopic("Core Initiator Initialized");
        }
    }
}

