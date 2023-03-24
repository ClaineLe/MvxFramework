using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.ViewModels;
using MvxFramework.UnityEngine.Core;
using UnityEngine;

namespace Playground
{
    public class Launcher : MonoBehaviour
    {
        public async Task Start()
        {
            this.RegisterSetupType<Setup>();
            try
            {
                MvxUnitySetupSingleton.EnsureSingletonAvailable(SynchronizationContext.Current)
                    .EnsureInitialized();
                await RunAppStart();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        protected virtual async Task RunAppStart(object hint = null)
        {
            if (Mvx.IoCProvider?.TryResolve(out IMvxAppStart startup) == true && !startup.IsStarted)
            {
                await startup.StartAsync(GetAppStartHint(hint));
            }
        }

        protected virtual object GetAppStartHint(object hint = null)
        {
            return hint;
        }
    }
}