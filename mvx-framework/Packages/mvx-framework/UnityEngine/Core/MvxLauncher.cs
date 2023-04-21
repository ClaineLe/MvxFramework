using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.ViewModels;
using UnityEngine;
using UnityEngine.Services.LocalizeService;

namespace MvxFramework.UnityEngine.Core
{
    public abstract class MvxLauncher<T> : MonoBehaviour
        where T : MvxSetup,new()
    {
        /// <summary>
        /// 默认语言
        /// </summary>
        protected virtual LANG DefaultLanguage => LANG.zh_CN;
        
        public virtual async Task SetupStart()
        {
            this.RegisterSetupType<T>();
            try
            {
                MvxUnitySetupSingleton.EnsureSingletonAvailable(SynchronizationContext.Current)
                    .EnsureInitialized();
                
                Mvx.IoCProvider.Resolve<IMvxLocalizeService>().SetLanguage(DefaultLanguage);
                
                await RunAppStart();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        
        protected virtual async Task RunAppStart(object hint = null)
        {
            if (Mvx.IoCProvider.TryResolve(out IMvxAppStart startup) == true && !startup.IsStarted)
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